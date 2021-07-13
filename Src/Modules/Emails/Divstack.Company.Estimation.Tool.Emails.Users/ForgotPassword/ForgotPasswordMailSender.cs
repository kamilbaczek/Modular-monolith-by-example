using System;
using System.Threading.Tasks;
using System.Web;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword
{
    internal class ForgotPasswordMailSender : IForgotPasswordMailSender
    {
        private readonly IForgotPasswordMailConfiguration _configuration;
        private readonly IEmailModule _ieMailModule;

        public ForgotPasswordMailSender(IEmailModule ieMailModule, IForgotPasswordMailConfiguration configuration)
        {
            _ieMailModule = ieMailModule;
            _configuration = configuration;
        }

        public async Task
            SendForgotPasswordMail(string email, string token,
                Guid userId) // todo this is almost exactly like SendConfirmAccountMail - refactor it so no code is copied
        {
            if (string.IsNullOrWhiteSpace(_configuration.Format))
                throw new InvalidOperationException("Forgot password email format is not set");

            const string tokenPlaceholder = "{token}";
            const string userIdPlaceholder = "{userId}";
            var emailText = _configuration.Format
                .Replace(tokenPlaceholder, HttpUtility.UrlEncode(token))
                .Replace(userIdPlaceholder, HttpUtility.UrlEncode(userId.ToString()));

            await _ieMailModule.SendEmailAsync(email, _configuration.Subject, emailText);
        }
    }
}