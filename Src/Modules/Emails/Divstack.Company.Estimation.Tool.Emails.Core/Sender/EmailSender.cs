using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using static System.String;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender
{
    internal sealed class EmailSender : IEmailSender
    {
        private readonly IMailConfiguration _mailConfiguration;
        private readonly IBackgroundJobScheduler _backgroundJobScheduler;

        public EmailSender(IMailConfiguration mailConfiguration, IBackgroundJobScheduler backgroundJobScheduler)
        {
            _mailConfiguration = mailConfiguration;
            _backgroundJobScheduler = backgroundJobScheduler;
        }

        public void Send(string email, string subject, string text)
        {
            if (!IsNullOrEmpty(_mailConfiguration.MailFrom))
            {
                _backgroundJobScheduler.Run(() => SendMessageAsync(email, subject, text));
            }
        }

        private bool IsConfiguredAuthentication() => !IsNullOrEmpty(_mailConfiguration.ServerLogin)
                                                     && !IsNullOrEmpty(_mailConfiguration.ServerPassword);

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
                await client.AuthenticateAsync(_mailConfiguration.ServerLogin, _mailConfiguration.ServerPassword);
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
}
