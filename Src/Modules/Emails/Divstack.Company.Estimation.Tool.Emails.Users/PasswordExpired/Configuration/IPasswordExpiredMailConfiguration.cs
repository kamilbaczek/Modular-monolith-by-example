namespace Divstack.Company.Estimation.Tool.Emails.Users.PasswordExpired.Configuration;

internal interface IPasswordExpiredMailConfiguration
{
    string Subject { get; }
    string Format { get; }
}
