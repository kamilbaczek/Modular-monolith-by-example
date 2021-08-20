using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalRejectedDomainEvent : DomainEventBase
    {
        internal ProposalRejectedDomainEvent(
            ValuationId valuationId,
            ProposalId proposalId,
            Money value,
            Email clientEmail)
        {
            ProposalId = proposalId;
            Value = value;
            ClientEmail = clientEmail;
            ValuationId = valuationId;
        }

        public Money Value { get; }
        public Email ClientEmail { get; }
        public ValuationId ValuationId { get; }
        public ProposalId ProposalId { get; }
    }
}
