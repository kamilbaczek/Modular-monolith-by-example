namespace Divstack.Company.Estimation.Tool.Emails.Users.PasswordExpired;

using System;
using System.Web;
using Configuration;
using Core;

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
        {
            throw new InvalidOperationException("Password Expired email format is not set");
        }

        const string userIdPlaceholder = "{userId}";
        const string tokenPlaceholder = "{token}";
        var emailText = configuration.Format
            .Replace(userIdPlaceholder, HttpUtility.UrlEncode(userId.ToString()))
            .Replace(tokenPlaceholder, HttpUtility.UrlEncode(token));

        _emailSender.Send(email, configuration.Subject, emailText);
    }
}
