namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public record PaymentId(Guid Value)
{
    internal static PaymentId Create() => new(Guid.NewGuid());

    public static PaymentId Of(Guid id) => new(id);
}
