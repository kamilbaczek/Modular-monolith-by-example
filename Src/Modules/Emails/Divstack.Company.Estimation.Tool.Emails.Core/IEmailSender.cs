namespace Divstack.Company.Estimation.Tool.Emails.Core;

public interface IEmailSender
{
    void Send(string email, string subject, string text);
}
