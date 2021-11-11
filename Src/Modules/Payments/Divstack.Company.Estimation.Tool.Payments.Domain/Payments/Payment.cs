using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Payers;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class Payment
{
    private PaymentId PaymentId { get; init; }
    private Payer Payer { get; init; }
    private PaymentStatus PaymentStatus { get; set; }
    private Money Charge { get; init; }

    private Payment(Payer payer, Money charge)
    {
        PaymentId = PaymentId.Create();
        Payer = Guard.Against.Null(payer, nameof(payer));
        PaymentStatus = PaymentStatus.WaitForPayment;
        Charge = Guard.Against.Null(charge, nameof(charge)); ;
    }

    public static Payment Initialize(Payer payer, Money charge)
    {
        return new Payment(payer, charge);
    }

    public void Pay()
    {
        PaymentStatus = PaymentStatus.Payed;
    }
}
