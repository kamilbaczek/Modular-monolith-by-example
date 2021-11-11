namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Events;

public sealed class InquiryMadeDomainEvent : DomainEventBase
{
    public InquiryMadeDomainEvent(InquiryId inquiryId)
    {
        InquiryId = inquiryId;
    }

    public InquiryId InquiryId { get; }
}
