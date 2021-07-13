using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalCancelledEvent : DomainEventBase
    {
        public ProposalCancelledEvent(EmployeeId cancelledBy, ProposalId proposalId)
        {
            CancelledBy = cancelledBy;
            ProposalId = proposalId;
        }

        public EmployeeId CancelledBy { get; }
        public ProposalId ProposalId { get; }
    }
}