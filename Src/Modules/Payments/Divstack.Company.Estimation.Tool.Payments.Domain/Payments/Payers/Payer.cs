namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Payers;

public sealed class Payer : ValueObject
{
    private Payer(PayerId payerId)
    {
        PayerId = Guard.Against.Null(payerId, nameof(payerId));
    }

    private PayerId PayerId { get; }

    public static Payer Of(PayerId payerId)
    {
        return new Payer(payerId);
    }
}
