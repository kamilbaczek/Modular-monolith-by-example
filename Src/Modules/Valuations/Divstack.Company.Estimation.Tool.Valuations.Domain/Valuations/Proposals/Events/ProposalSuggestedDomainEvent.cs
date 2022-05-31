namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalSuggestedDomainEvent : DomainEventBase
{
    public ProposalSuggestedDomainEvent(
        Proposal proposal,
        ValuationId valuationId,
        InquiryId inquiryId)
    {
        Proposal = proposal;
        InquiryId = inquiryId;
        ValuationId = valuationId;
    }

    public Proposal Proposal { get; }
    public InquiryId InquiryId { get; }
    public ValuationId ValuationId { get; }
}
