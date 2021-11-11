using System;
using System.Web;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Sender;

internal class ConfirmAccountMailSender : IConfirmAccountMailSender
{
    private readonly IConfirmAccountMailConfiguration _confirmAccountMailConfiguration;
    private readonly IEmailSender _mailSender;

    public ConfirmAccountMailSender(IConfirmAccountMailConfiguration confirmAccountMailConfiguration,
        IEmailSender mailSender)
    {
        _confirmAccountMailConfiguration = confirmAccountMailConfiguration;
        _mailSender = mailSender;
    }

    public void Send(string email, string token, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(_confirmAccountMailConfiguration.Format))
            throw new InvalidOperationException("Confirmation email format is not set");

        const string userIdPlaceholder = "{userId}";
        const string tokenPlaceholder = "{token}";
        var emailText = _confirmAccountMailConfiguration.Format
            .Replace(userIdPlaceholder, HttpUtility.UrlEncode(userId.ToString()))
            .Replace(tokenPlaceholder, HttpUtility.UrlEncode(token));

        _mailSender.Send(email, _confirmAccountMailConfiguration.Subject, emailText);
    }
}
