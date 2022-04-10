namespace Divstack.Company.Estimation.Tool.Emails.Core.Sender;

using Configuration;
using Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shared.Abstractions.BackgroundProcessing;
using static String;

internal sealed class EmailSender : IEmailSender
{
    private readonly IBackgroundProcessQueue _backgroundProcessQueue;
    private readonly IMailConfiguration _mailConfiguration;
    private const string EmailType = "text/html";

    public EmailSender(IMailConfiguration mailConfiguration, IBackgroundProcessQueue backgroundProcessQueue)
    {
        _mailConfiguration = mailConfiguration;
        _backgroundProcessQueue = backgroundProcessQueue;
    }

    public void Send(string email, string subject, string text)
    {
        if (!IsNullOrEmpty(_mailConfiguration.MailFrom))
        {
            _backgroundProcessQueue.Enqueue(() => SendMessageAsync(email, subject, text));
        }
    }

    public async Task SendMessageAsync(string email, string subject, string text)
    {
        var client = new SendGridClient(_mailConfiguration.ApiKey);

        var message = BuildMessage(email, subject, text);

        await client.SendEmailAsync(message);
    }

    private SendGridMessage BuildMessage(string email, string subject, string text)
    {
        var message = new SendGridMessage();
        message.AddTo(email);
        message.AddContent(EmailType, text);

        var fromEmailAddress = new EmailAddress(_mailConfiguration.MailFrom);
        message.SetFrom(fromEmailAddress);
        message.SetSubject(subject);

        return message;
    }
}
