using System;
using System.Threading.Tasks;
using System.Web;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Sender
{
    internal class ConfirmAccountMailSender : IConfirmAccountMailSender
    {
        private readonly IConfirmAccountMailConfiguration _confirmAccountMailConfiguration;
        private readonly IEmailModule _ieMailModule;

        public ConfirmAccountMailSender(IConfirmAccountMailConfiguration confirmAccountMailConfiguration,
            IEmailModule ieMailModule)
        {
            _confirmAccountMailConfiguration = confirmAccountMailConfiguration;
            _ieMailModule = ieMailModule;
        }

        public async Task SendConfirmationEmailAsync(string email, string token, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(_confirmAccountMailConfiguration.Format))
                throw new InvalidOperationException("Confirmation email format is not set");

            const string userIdPlaceholder = "{userId}";
            const string tokenPlaceholder = "{token}";
            var emailText = _confirmAccountMailConfiguration.Format
                .Replace(userIdPlaceholder, HttpUtility.UrlEncode(userId.ToString()))
                .Replace(tokenPlaceholder, HttpUtility.UrlEncode(token));

            await _ieMailModule.SendEmailAsync(email, _confirmAccountMailConfiguration.Subject, emailText);
        }
    }
}