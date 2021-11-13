namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Events;

public sealed class PaymentInitializedDomainEvent : DomainEventBase
{
    public PaymentInitializedDomainEvent(PaymentId paymentId, ValuationId valuationId, InquiryId inquiryId, Money amountToPay)
    {
        PaymentId = paymentId;
        ValuationId = valuationId;
        InquiryId = inquiryId;
        AmountToPay = amountToPay;
    }

    public PaymentId PaymentId { get; }
    public ValuationId ValuationId { get; }
    public InquiryId InquiryId { get; }
    public Money AmountToPay { get; }
}
