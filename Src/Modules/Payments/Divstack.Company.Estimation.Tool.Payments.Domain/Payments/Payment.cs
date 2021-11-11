using Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Payers;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class Payment
{
    private Payment(Payer payer, Money charge)
    {
        PaymentId = PaymentId.Create();
        Payer = Guard.Against.Null(payer, nameof(payer));
        PaymentStatus = PaymentStatus.WaitForPayment;
        Charge = Guard.Against.Null(charge, nameof(charge));
        ;
    }

    private PaymentId PaymentId { get; }
    private Payer Payer { get; }
    private PaymentStatus PaymentStatus { get; set; }
    private Money Charge { get; }

    public static Payment Initialize(Payer payer, Money charge)
    {
        return new Payment(payer, charge);
    }

    public void Pay()
    {
        PaymentStatus = PaymentStatus.Payed;
    }
}
