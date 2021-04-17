using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalApprovedEvent : DomainEventBase
    {
        public ProposalApprovedEvent(ProposalId proposalId, Email clientEmail)
        {
            ProposalId = proposalId;
            ClientEmail = clientEmail;
        }

        public ProposalId ProposalId { get; }
        public Email ClientEmail { get; }
    }
}
