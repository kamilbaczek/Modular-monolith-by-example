using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalRejectedEvent : DomainEventBase
    {
        public ProposalRejectedEvent(string reasonMessage, ProposalId proposalId)
        {
            ReasonMessage = reasonMessage;
            ProposalId = proposalId;
        }

        public string ReasonMessage { get;}
        public ProposalId  ProposalId { get;}
    }
}
