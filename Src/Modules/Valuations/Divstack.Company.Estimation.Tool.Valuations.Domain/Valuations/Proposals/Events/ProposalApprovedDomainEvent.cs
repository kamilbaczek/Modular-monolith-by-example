using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalApprovedDomainEvent : DomainEventBase
{
    internal ProposalApprovedDomainEvent(
        ValuationId valuationId,
        ProposalId proposalId,
        Money value,
        EmployeeId suggestedBy)
    {
        ProposalId = proposalId;
        Value = value;
        SuggestedBy = suggestedBy;
        ValuationId = valuationId;
    }

    public Money Value { get; }
    public ValuationId ValuationId { get; }
    public ProposalId ProposalId { get; }
    public EmployeeId SuggestedBy { get; }
}
