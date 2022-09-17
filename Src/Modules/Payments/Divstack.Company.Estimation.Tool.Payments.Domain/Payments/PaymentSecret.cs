namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class PaymentSecret : ValueObject
{
    private PaymentSecret(string value) =>
        Value = Guard.Against.NullOrEmpty(value, nameof(Payment));

    public string Value { get; init; }
    public static PaymentSecret Of(string value) => new(value);
}
