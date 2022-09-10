namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Tests;

using Application.Authentication;
using Domain;
using Domain.Users;
using Domain.Users.Interfaces;
using Identity.Jwt.RefreshTokens;
using Identity.Users.Services;
using Microsoft.AspNetCore.Identity;

public class SignInManagementServiceTests
{
    private readonly SignInManagementService _signInManagementService;
    private readonly IDateTimeProvider _datetimeProvider = Substitute.For<IDateTimeProvider>();
    private readonly ICurrentUserService _currentUserService = Substitute.For<ICurrentUserService>();
    private readonly IRefreshTokenRepository _refreshTokenRepository = Substitute.For<IRefreshTokenRepository>();
    private readonly ISignInManager _signInManager = Substitute.For<ISignInManager>();
    private readonly ITokenStoreManager _tokenStoreManager = Substitute.For<ITokenStoreManager>();
    private readonly IUsersRepository _usersRepository = Substitute.For<IUsersRepository>();
    private readonly IUsersConfiguration _usersConfiguration = Substitute.For<IUsersConfiguration>();
    private readonly IPasswordTokens _passwordTokens = Substitute.For<IPasswordTokens>();

    private const int OneWeek = 7;
    private const int ThreeDays = 3;

    public SignInManagementServiceTests()
    {
        _signInManagementService = new SignInManagementService(
            _signInManager,
            _usersRepository,
            _tokenStoreManager,
            _refreshTokenRepository,
            _currentUserService,
            _datetimeProvider,
            _passwordTokens);
    }

    [Test]
    public async Task Given_SignIn_When_UserPasswordExpired_Then_GeneratePasswordResetToken()
    {
        var user = UserAccountFaker.Create();
        SetupPasswordExpiration(ThreeDays);
        RenewPasswordExpiration(user);
        SimulateTimePassage(OneWeek);
        SetupGetByUserName(user);
        SetupSuccessfulPasswordSignIn();
        var signInRequest = SignInRequestFaker.Create();

        await _signInManagementService.SignInAsync(signInRequest);

        await EnsureThatPasswordResetTokenGenerated();
    }

    private async Task EnsureThatPasswordResetTokenGenerated() => await _passwordTokens.Received().GeneratePasswordResetTokenAsync(Arg.Any<UserAccount>());

    private void SimulateTimePassage(int passedDays)
    {
        var dateTime = new DateTime(2022, 1, 1);
        _datetimeProvider.NowDate.Returns(dateTime.AddDays(passedDays));
    }

    private void SetupSuccessfulPasswordSignIn()
    {
        _signInManager.PasswordSignInAsync(
                Arg.Any<UserAccount>(),
                Arg.Any<string>(),
                Arg.Any<bool>(),
                Arg.Any<bool>())
            .Returns(SignInResult.Success);
    }

    private void SetupGetByUserName(UserAccount user)
    {
        _usersRepository.GetByUserNameAsync(Arg.Any<string>())
            .Returns(user);
    }

    private void SetupPasswordExpiration(int days) => _usersConfiguration.PasswordExpirationFrequency.Returns(days);


    private void RenewPasswordExpiration(UserAccount user) => user.RenewPasswordExpiration(_datetimeProvider, _usersConfiguration);
}
