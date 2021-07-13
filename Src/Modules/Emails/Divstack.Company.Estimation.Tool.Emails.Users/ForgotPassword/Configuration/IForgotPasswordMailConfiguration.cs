namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword.Configuration
{
    internal interface IForgotPasswordMailConfiguration
    {
        string Subject { get; }
        string Format { get; }
    }
}