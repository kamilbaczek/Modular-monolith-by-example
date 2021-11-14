namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class PaymentMethod : ValueObject
{
    private PaymentMethod(string value)
    {
        Value = Guard.Against.NullOrEmpty(value, nameof(Payment));
    }
    public static PaymentMethod Of(string value)
    {
        return new PaymentMethod(value);
    }
    
    public string Value { get; init; }
}
