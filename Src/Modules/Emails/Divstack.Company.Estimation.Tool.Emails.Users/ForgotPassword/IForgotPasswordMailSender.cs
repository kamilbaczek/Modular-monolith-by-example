namespace Divstack.Company.Estimation.Tool.Emails.Users.ForgotPassword;

using System;

internal interface IForgotPasswordMailSender
{
    void Send(string email, string token, Guid userId);
}
