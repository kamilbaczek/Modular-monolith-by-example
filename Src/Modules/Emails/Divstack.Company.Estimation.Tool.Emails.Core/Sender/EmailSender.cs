using static System.String;

namespace Divstack.Company.Estimation.Tool.Emails.Core.Sender;

using Configuration;
using Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Shared.Abstractions.BackgroundProcessing;

internal sealed class EmailSender : IEmailSender
{
    private readonly IBackgroundProcessQueue _backgroundProcessQueue;
    private readonly IMailConfiguration _mailConfiguration;

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

    private bool IsConfiguredAuthentication()
    {
        return !IsNullOrEmpty(_mailConfiguration.ServerLogin)
               && !IsNullOrEmpty(_mailConfiguration.ServerPassword);
    }

    public async Task SendMessageAsync(string email, string subject, string text)
    {
        var message = BuildMessage(email, subject, text);
        using var client = new SmtpClient();
        if (_mailConfiguration.DisableSsl)
        {
            DisableSsl(client);
        }

        await client.ConnectAsync(_mailConfiguration.ServerAddress, _mailConfiguration.ServerPort);
        if (IsConfiguredAuthentication())
        {
            await client.AuthenticateAsync(_mailConfiguration.ServerLogin, _mailConfiguration.ServerPassword);
        }

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    private MimeMessage BuildMessage(string email, string subject, string text)
    {
        var message = new MimeMessage();
        var mailFrom = IsConfiguredAuthentication()
            ? new MailboxAddress(_mailConfiguration.MailFrom, _mailConfiguration.ServerLogin)
            : MailboxAddress.Parse(_mailConfiguration.MailFrom);
        message.From.Add(mailFrom);
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = subject;
        message.Body = new TextPart(TextFormat.Html)
        {
            Text = text
        };

        return message;
    }

    private static void DisableSsl(SmtpClient client)
    {
        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
        client.CheckCertificateRevocation = false;
    }
}
