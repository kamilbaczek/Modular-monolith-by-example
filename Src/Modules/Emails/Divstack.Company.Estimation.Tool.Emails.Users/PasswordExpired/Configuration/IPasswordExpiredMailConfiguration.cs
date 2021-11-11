namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired.Configuration;

internal interface IPasswordExpiredMailConfiguration
{
    string Subject { get; }
    string Format { get; }
}
