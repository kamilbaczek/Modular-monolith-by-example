using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events
{
    public sealed class ProposalRejectedEvent : DomainEventBase
    {
        public ProposalRejectedEvent(string reasonMessage, ProposalId proposalId, Email employeeEmail)
        {
            ReasonMessage = reasonMessage;
            ProposalId = proposalId;
            EmployeeEmail = employeeEmail;
        }

        public string ReasonMessage { get;}
        public ProposalId  ProposalId { get;}
        public Email EmployeeEmail { get; }
    }
}
