namespace Divstack.Company.Estimation.Tool.Emails.Users.ForgotPassword.Configuration;

internal interface IForgotPasswordMailConfiguration
{
    string Subject { get; }
    string Format { get; }
}
