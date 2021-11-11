using Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Payers;

namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class Payment
{
    private Payment(ValuationId valuationId, Money charge)
    {
        ValuationId = valuationId;
        PaymentId = PaymentId.Create();
        PaymentStatus = PaymentStatus.WaitForPayment;
        Charge = Guard.Against.Null(charge, nameof(charge));
    }

    private PaymentId PaymentId { get; init; }
    private ValuationId ValuationId { get; init; }
    private PaymentStatus PaymentStatus { get; set; }
    private Money Charge { get; init; }

    public static Payment Initialize(ValuationId valuationId, Money charge)
    {
        return new Payment(valuationId, charge);
    }

    public void Pay()
    {
        PaymentStatus = PaymentStatus.Payed;
    }
}
