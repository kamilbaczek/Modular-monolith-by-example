namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Exceptions;

public sealed class PaymentAlreadyPayedException : InvalidOperationException
{
    private static string GetMessage(PaymentId paymentId) => $"Payment {paymentId.Value} already Payed";
    public PaymentAlreadyPayedException(PaymentId paymentId) : base(GetMessage(paymentId))
    {
    }
}
