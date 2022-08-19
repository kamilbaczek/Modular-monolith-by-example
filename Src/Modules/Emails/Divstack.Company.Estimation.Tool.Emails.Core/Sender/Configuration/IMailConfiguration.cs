namespace Divstack.Company.Estimation.Tool.Emails.Core.Sender.Configuration;

internal interface IMailConfiguration
{
    string MailFrom { get; }
    string ApiKey { get; }
}
