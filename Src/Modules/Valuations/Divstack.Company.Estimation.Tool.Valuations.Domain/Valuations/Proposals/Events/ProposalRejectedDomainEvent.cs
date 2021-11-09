using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalRejectedDomainEvent : DomainEventBase
    {
        internal ProposalRejectedDomainEvent(
            ValuationId valuationId,
            ProposalId proposalId,
            Money value)
        {
            ProposalId = proposalId;
            Value = value;
            ValuationId = valuationId;
        }

        public Money Value { get; }
        public ValuationId ValuationId { get; }
        public ProposalId ProposalId { get; }
    }
}