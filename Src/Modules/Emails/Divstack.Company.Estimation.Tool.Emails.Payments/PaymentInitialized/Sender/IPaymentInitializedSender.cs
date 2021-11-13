namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized.Sender;

internal interface IPaymentInitializedSender
{
    void Send(PaymentInitializedEmailRequest request);
}
