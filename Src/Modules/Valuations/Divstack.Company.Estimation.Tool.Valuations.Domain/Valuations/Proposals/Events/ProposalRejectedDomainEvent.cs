namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalRejectedDomainEvent : DomainEventBase
{
    internal ProposalRejectedDomainEvent(
        ValuationId valuationId,
        ProposalId proposalId,
        Money value)
    {
        ValuationId = valuationId;
        ProposalId = proposalId;
        Value = value;
    }

    public Money Value { get; }
    public ValuationId ValuationId { get; }
    public ProposalId ProposalId { get; }
}
