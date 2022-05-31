namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalApprovedDomainEvent : DomainEventBase
{
    internal ProposalApprovedDomainEvent(
        ValuationId valuationId,
        Proposal proposal)
    {
        ValuationId = valuationId;
        Proposal = proposal;
    }

    public ValuationId ValuationId { get; }
    public Proposal Proposal { get; }
}
