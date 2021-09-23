using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
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
}