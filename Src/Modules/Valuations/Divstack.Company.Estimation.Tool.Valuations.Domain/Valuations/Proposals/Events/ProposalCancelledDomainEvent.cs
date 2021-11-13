namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

using Shared.DDD.BuildingBlocks;

public sealed class ProposalCancelledDomainEvent : DomainEventBase
{
    public ProposalCancelledDomainEvent(EmployeeId cancelledBy, ProposalId proposalId, ValuationId valuationId)
    {
        CancelledBy = cancelledBy;
        ProposalId = proposalId;
        ValuationId = valuationId;
    }

    public EmployeeId CancelledBy { get; }
    public ProposalId ProposalId { get; }
    public ValuationId ValuationId { get; }
}
