namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Configuration
{
    internal interface IMailConfiguration
    {
        string ServerAddress { get; }
        int ServerPort { get; }
        string ServerLogin { get; }
        string ServerPassword { get; }
        string MailFrom { get; }
        bool DisableSsl { get; }
    }
}