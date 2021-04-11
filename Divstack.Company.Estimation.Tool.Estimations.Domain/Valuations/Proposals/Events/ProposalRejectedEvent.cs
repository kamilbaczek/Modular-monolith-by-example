using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalRejectedEvent : DomainEventBase
    {
        public ProposalRejectedEvent(string reasonMessage, ProposalId proposalId, Email clientEmail)
        {
            ReasonMessage = reasonMessage;
            ProposalId = proposalId;
            ClientEmail = clientEmail;
        }

        public string ReasonMessage { get;}
        public ProposalId  ProposalId { get;}
        public Email ClientEmail { get; }
    }
}
