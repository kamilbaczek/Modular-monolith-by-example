namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted.Sender;

internal interface IPaymentCompletedSender
{
    void Send(PaymentCompletedEmailRequest request);
}
