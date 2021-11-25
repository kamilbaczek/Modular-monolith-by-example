namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Exceptions;

public sealed class PaymentAlreadyPayedException : InvalidOperationException
{
    public PaymentAlreadyPayedException(PaymentId paymentId) : base(GetMessage(paymentId))
    {
    }
    private static string GetMessage(PaymentId paymentId)
    {
        return $"Payment {paymentId.Value} already Payed";
    }
}
