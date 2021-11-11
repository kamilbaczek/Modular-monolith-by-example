using System;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired;

internal interface IPasswordExpiredMailSender
{
    void Send(string email, string token, Guid userId);
}
