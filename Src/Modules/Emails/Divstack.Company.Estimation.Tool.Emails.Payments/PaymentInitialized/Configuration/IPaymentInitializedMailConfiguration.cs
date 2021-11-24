namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized.Configuration;

internal interface IPaymentInitializedMailConfiguration
{
    string Subject { get; }
    string PaymentUrl { get; }
    string PathToTemplate { get; }
}
