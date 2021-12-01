namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments.Events;

public sealed class PaymentCompletedDomainEvent : DomainEventBase
{
    public PaymentCompletedDomainEvent(PaymentId paymentId, InquiryId inquiryId)
    {
        PaymentId = paymentId;
        InquiryId = inquiryId;
    }

    public PaymentId PaymentId { get; }
    public InquiryId InquiryId { get; }
}
