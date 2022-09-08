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
    public async Task Given_SignIn_When_UserPasswordExpired_Then_SendResetPasswordEmail()
    {
        var user = UserAccount.Create("", "", true, "");
        _usersConfiguration.PasswordExpirationFrequency.Returns(2);
        user.RenewPasswordExpiration(_datetimeProvider, _usersConfiguration);
        _usersConfiguration.PasswordExpirationFrequency.Returns(2);
        var dateTime = new DateTime(2022, 1, 1);
        _datetimeProvider.NowDate.Returns(dateTime.AddDays(8));
        _usersRepository.GetByUserNameAsync(Arg.Any<string>()).Returns(
            user);
        _signInManager.PasswordSignInAsync(
                Arg.Any<UserAccount>(),
                Arg.Any<string>(),
                Arg.Any<bool>(),
                Arg.Any<bool>())
            .Returns(SignInResult.Success);
        var signInRequest = new SignInRequest("fdsf", "fdsaf");

        await _signInManagementService.SignInAsync(signInRequest);

        await _passwordTokens.Received().GeneratePasswordResetTokenAsync(Arg.Any<UserAccount>());
    }
}
