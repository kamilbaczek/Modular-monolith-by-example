using System;
using System.Web;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword;

internal class ForgotPasswordMailSender : IForgotPasswordMailSender
{
    private readonly IForgotPasswordMailConfiguration _configuration;
    private readonly IEmailSender _emailSender;

    public ForgotPasswordMailSender(IEmailSender emailSender, IForgotPasswordMailConfiguration configuration)
    {
        _emailSender = emailSender;
        _configuration = configuration;
    }

    public void
        Send(string email, string token,
            Guid userId)
    {
        if (string.IsNullOrWhiteSpace(_configuration.Format))
            throw new InvalidOperationException("Forgot password email format is not set");

        const string tokenPlaceholder = "{token}";
        const string userIdPlaceholder = "{userId}";
        var emailText = _configuration.Format
            .Replace(tokenPlaceholder, HttpUtility.UrlEncode(token))
            .Replace(userIdPlaceholder, HttpUtility.UrlEncode(userId.ToString()));

        _emailSender.Send(email, _configuration.Subject, emailText);
    }
}
