using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Domain;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services
{
    internal class SignInManagementService : ISignInManagementService
    {
        private readonly IDateTimeProvider _datetimeProvider;
        private readonly ICurrentUserService currentUserService;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly SignInManager<UserAccount> signInManager;
        private readonly ITokenStoreManager tokenStoreManager;
        private readonly UserManager<UserAccount> userManager;

        public SignInManagementService(SignInManager<UserAccount> signInManager,
            UserManager<UserAccount> userManager,
            ITokenStoreManager tokenStoreManager,
            IRefreshTokenRepository refreshTokenRepository,
            ICurrentUserService currentUserService,
            IDateTimeProvider datetimeProvider)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenStoreManager = tokenStoreManager;
            this.refreshTokenRepository = refreshTokenRepository;
            this.currentUserService = currentUserService;
            _datetimeProvider = datetimeProvider;
        }

        public async Task<SignInResultStatus> SignInAsync(string userName, string password)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user is null)
                return SignInResultStatus.Negative;

            var signInResult = await signInManager.PasswordSignInAsync(user, password, true, true);
            if (signInResult.IsLockedOut) return SignInResultStatus.Locked;
            if (!signInResult.Succeeded) return SignInResultStatus.Negative;
            if (!user.IsPasswordExpired(_datetimeProvider))
            {
                user.SignIn(_datetimeProvider);
                await userManager.UpdateAsync(user);

                return SignInResultStatus.Positive;
            }

            await SendResetPasswordMail(user);
            user.AccessFailedCount++;
            await userManager.UpdateAsync(user);

            return SignInResultStatus.ExpiredPassword;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
            await tokenStoreManager.DeactivateCurrentAsync();
            var userPublicId = currentUserService.GetPublicUserId();
            await refreshTokenRepository.RemoveForUserAsync(userPublicId);
        }

        public async Task SaveLogForFailedLoginAttemptAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.UserName == userName, cancellationToken);
            if (user is null) return;
            user.RegisterFailedLoginAttempt(_datetimeProvider.Now);
            await userManager.UpdateAsync(user);
        }

        private async Task SendResetPasswordMail(UserAccount userAccount)
        {
            var resetPasswordToken = await userManager.GeneratePasswordResetTokenAsync(userAccount);
        }
    }
}