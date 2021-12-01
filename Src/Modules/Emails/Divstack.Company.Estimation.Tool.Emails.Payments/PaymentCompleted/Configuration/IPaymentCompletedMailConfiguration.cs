namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted.Configuration;

internal interface IPaymentCompletedMailConfiguration
{
    string Subject { get; }
    string PathToTemplate { get; }
}
