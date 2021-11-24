namespace Divstack.Company.Estimation.Tool.Emails.Users.ConfirmAccount.Configuration;

internal interface IConfirmAccountMailConfiguration
{
    string Subject { get; }
    string Format { get; }
}
