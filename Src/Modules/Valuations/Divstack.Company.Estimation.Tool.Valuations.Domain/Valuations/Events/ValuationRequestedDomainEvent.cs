namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

public sealed class ValuationRequestedDomainEvent : DomainEventBase
{
    public ValuationRequestedDomainEvent(
        ValuationId valuationId,
        InquiryId inquiryId)
    {
        ValuationId = valuationId;
        InquiryId = inquiryId;
    }

    public ValuationId ValuationId { get; }
    public InquiryId InquiryId { get; }
}
