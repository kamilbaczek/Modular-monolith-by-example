namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

using Events;

public sealed class Payment : Entity, IAggregateRoot
{
    private Payment(ValuationId valuationId, InquiryId inquiryId, Money amountToPay)
    {
        ValuationId = Guard.Against.Null(valuationId, nameof(valuationId));
        PaymentId = PaymentId.Create();
        PaymentStatus = PaymentStatus.WaitForPayment;
        AmountToPay = Guard.Against.Null(amountToPay, nameof(amountToPay));
        InquiryId = Guard.Against.Null(inquiryId, nameof(inquiryId));
        var @event = new PaymentInitializedDomainEvent(PaymentId, ValuationId, InquiryId, AmountToPay);
        AddDomainEvent(@event);
    }

    public PaymentId PaymentId { get; }
    private ValuationId ValuationId { get; }
    private InquiryId InquiryId { get; }
    private PaymentStatus PaymentStatus { get; set; }
    private Money AmountToPay { get; }

    public static Payment Initialize(ValuationId valuationId, InquiryId inquiryId, Money amountToPay)
    {
        return new Payment(valuationId, inquiryId, amountToPay);
    }

    public void Pay()
    {
        PaymentStatus = PaymentStatus.Payed;
    }
}
