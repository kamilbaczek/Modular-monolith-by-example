using System;
using System.Threading.Tasks;
using System.Web;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired
{
    internal sealed class PasswordExpiredMailSender : IPasswordExpiredMailSender
    {
        private readonly IEmailSender _emailSender;
        private readonly IPasswordExpiredMailConfiguration configuration;

        public PasswordExpiredMailSender(IPasswordExpiredMailConfiguration configuration, IEmailSender emailSender)
        {
            this.configuration = configuration;
            _emailSender = emailSender;
        }

        public void Send(string email, string token, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(configuration.Format))
                throw new InvalidOperationException("Password Expired email format is not set");

            const string userIdPlaceholder = "{userId}";
            const string tokenPlaceholder = "{token}";
            var emailText = configuration.Format
                .Replace(userIdPlaceholder, HttpUtility.UrlEncode(userId.ToString()))
                .Replace(tokenPlaceholder, HttpUtility.UrlEncode(token));

            _emailSender.Send(email, configuration.Subject, emailText);
        }
    }
}
