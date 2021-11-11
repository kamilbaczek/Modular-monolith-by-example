namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Payers;

public sealed class Payer : ValueObject
{
    private Payer(PayerId payerId)
    {
        PayerId = Guard.Against.Null(payerId, nameof(payerId));
    }

    private PayerId PayerId { get; init; }

    public static Payer Of(Guid payerId)
    {
        var id = PayerId.Of(payerId);
        return new Payer(id);
    }
}
