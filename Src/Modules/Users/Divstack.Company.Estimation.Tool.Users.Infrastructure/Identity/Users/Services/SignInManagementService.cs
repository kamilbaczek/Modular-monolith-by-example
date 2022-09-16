namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System.Threading;
using System.Threading.Tasks;
using Application.Authentication;
using Domain;
using Domain.Users;
using Jwt.RefreshTokens;

internal sealed class SignInManagementService : ISignInManagementService
{
    private readonly IDateTimeProvider _datetimeProvider;
    private readonly IPasswordTokens _passwordTokens;
    private readonly ICurrentUserService _currentUserService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ISignInManager _signInManager;
    private readonly IUsersRepository _usersRepository;
    private readonly ITokenStoreManager _tokenStoreManager;

    public SignInManagementService(ISignInManager signInManager,
        IUsersRepository usersRepository,
        ITokenStoreManager tokenStoreManager,
        IRefreshTokenRepository refreshTokenRepository,
        ICurrentUserService currentUserService,
        IDateTimeProvider datetimeProvider,
        IPasswordTokens passwordTokens)
    {
        _signInManager = signInManager;
        _usersRepository = usersRepository;
        _tokenStoreManager = tokenStoreManager;
        _refreshTokenRepository = refreshTokenRepository;
        _currentUserService = currentUserService;
        _datetimeProvider = datetimeProvider;
        _passwordTokens = passwordTokens;
    }

    public async Task<SignInResultStatus> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _usersRepository.GetByUserNameAsync(request.UserName, cancellationToken);
        if (user is null)
            return SignInResultStatus.Negative;

        var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);
        if (signInResult.IsLockedOut)
            return SignInResultStatus.Locked;

        if (!signInResult.Succeeded)
            return SignInResultStatus.Negative;

        if (!user.IsPasswordExpired(_datetimeProvider))
        {
            user.SignIn(_datetimeProvider);
            await _usersRepository.UpdateAsync(user, cancellationToken);

            return SignInResultStatus.Positive;
        }

        await SendResetPasswordMail(user);
        user.AccessFailedCount++;
        await _usersRepository.UpdateAsync(user, cancellationToken);

        return SignInResultStatus.ExpiredPassword;
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
        await _tokenStoreManager.DeactivateCurrentAsync();
        var userPublicId = _currentUserService.GetPublicUserId();
        await _refreshTokenRepository.RemoveForUserAsync(userPublicId);
    }

    public async Task SaveLogForFailedLoginAttemptAsync(string userName, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByUserNameAsync(userName, cancellationToken);
        if (user is null)
            return;

        user.RegisterFailedLoginAttempt(_datetimeProvider.Now);
        await _usersRepository.UpdateAsync(user, cancellationToken);
    }

    private async Task SendResetPasswordMail(UserAccount userAccount)
    {
        _ = await _passwordTokens.GeneratePasswordResetTokenAsync(userAccount);
    }
}
