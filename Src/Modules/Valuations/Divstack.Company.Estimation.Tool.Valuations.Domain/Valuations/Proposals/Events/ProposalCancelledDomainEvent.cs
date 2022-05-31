namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalCancelledDomainEvent : DomainEventBase
{
    public ProposalCancelledDomainEvent(
        InquiryId inquiryId,
        ValuationId valuationId,
        Proposal proposal)
    {
        InquiryId = inquiryId;
        ValuationId = valuationId;
        Proposal = proposal;
    }

    public InquiryId InquiryId { get; }
    public ValuationId ValuationId { get; }
    public Proposal Proposal { get; }
}
