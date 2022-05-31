namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalRejectedDomainEvent : DomainEventBase
{
    internal ProposalRejectedDomainEvent(
        ValuationId valuationId,
        Proposal proposal)
    {
        ValuationId = valuationId;
    }

    public Money Value { get; }
    public ValuationId ValuationId { get; }
    public ProposalId ProposalId { get; }
}
