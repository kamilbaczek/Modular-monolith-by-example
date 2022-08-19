namespace Divstack.Company.Estimation.Tool.Emails.Users.PasswordExpired;

using System;

internal interface IPasswordExpiredMailSender
{
    void Send(string email, string token, Guid userId);
}
