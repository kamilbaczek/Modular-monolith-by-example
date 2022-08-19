namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SignIn;

internal static class SignInErrorMessages
{
    internal const string PasswordOrLoginInvalid = "Login or password invalid";
    internal const string AccountLocked = "Your account is temporarily locked";
    internal static string PasswordExpired => "Password expired! Reset password link was sent to email";
}
