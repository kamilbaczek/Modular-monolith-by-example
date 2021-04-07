using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalApprovedEvent : DomainEventBase
    {
        public ProposalApprovedEvent(ProposalId proposalId)
        {
            ProposalId = proposalId;
        }

        public ProposalId ProposalId { get; }
    }
}
