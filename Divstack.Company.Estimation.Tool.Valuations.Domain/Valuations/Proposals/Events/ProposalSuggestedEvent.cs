using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalSuggestedEvent : DomainEventBase
    {
        public ProposalSuggestedEvent(EmployeeId proposedBy, Money value, ProposalId proposalId)
        {
            ProposedBy = proposedBy;
            Value = value;
            ProposalId = proposalId;
        }

        public ProposalId ProposalId { get;  }
        public EmployeeId ProposedBy { get;  }
        public Money Value { get;  }
    }
}
