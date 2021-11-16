namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class PaymentStatus : ValueObject
{
    private const string WaitForPaymentStatus = "WaitForPaymentStatus";
    private const string PayedStatus = "Payed";

    private PaymentStatus(string value)
    {
        Value = value;
    }

    internal static PaymentStatus WaitForPayment => new(WaitForPaymentStatus);
    internal static PaymentStatus Payed => new(PayedStatus);

    private string Value { get; init; }
}
