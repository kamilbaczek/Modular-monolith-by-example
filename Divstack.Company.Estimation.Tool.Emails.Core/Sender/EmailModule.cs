using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using static System.String;


namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender
{
    internal sealed class EmailModule : IEmailModule
    {
        private readonly IMailConfiguration _mailConfiguration;

        public EmailModule(IMailConfiguration mailConfiguration)
        {
            _mailConfiguration = mailConfiguration;
        }

        public async Task SendEmailAsync(string email, string subject, string text)
        {
            if (!IsNullOrEmpty(_mailConfiguration.ServerAddress) && !IsNullOrEmpty(_mailConfiguration.MailFrom)
            ) //TODO Handle Invalid Configuration
            {
                var message = BuildMessage(email, subject, text);
                await SendMessageAsync(message);
            }
        }

        private bool IsConfiguredAuthentication() => !IsNullOrEmpty(_mailConfiguration.ServerLogin)
                                                     && !IsNullOrEmpty(_mailConfiguration.ServerPassword);

        private async Task SendMessageAsync(MimeMessage message)
        {
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
                : new MailboxAddress(_mailConfiguration.MailFrom);
            message.From.Add(mailFrom);
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = Format(_mailConfiguration.MailTemplate, text)
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