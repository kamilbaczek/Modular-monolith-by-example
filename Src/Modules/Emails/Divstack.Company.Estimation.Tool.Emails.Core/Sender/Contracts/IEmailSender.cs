namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts
{
    public interface IEmailSender
    {
        void Send(string email, string subject, string text);
    }
}
