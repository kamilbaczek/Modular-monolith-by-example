namespace Divstack.Company.Estimation.Tool.Emails.Users.ConfirmAccount.Sender;

using System;

internal interface IConfirmAccountMailSender
{
    void Send(string email, string token, Guid userId);
}
