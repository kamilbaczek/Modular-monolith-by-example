using System;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Proposals;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Exceptions;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals
{
    public sealed class Proposal : Entity
    {
        internal ProposalId Id { get; }
        private ProposalDescription Description { get; }
        internal Money Value { get; }
        private EmployeeId SuggestedBy { get; }
        private DateTime Suggested { get; }
        private EmployeeId CancelledBy { get; set; }
        private DateTime? Cancelled { get; set; }
        private ProposalDecision Decision { get; set; }

        private Proposal(
            Money value,
            ProposalDescription description,
            EmployeeId suggestedBy)
        {
            Id = new ProposalId(Guid.NewGuid());
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Description = description ?? throw new ArgumentNullException(nameof(description));;
            SuggestedBy = suggestedBy ?? throw new ArgumentNullException(nameof(suggestedBy));
            Suggested = DateTime.Now;
            AddDomainEvent(new ProposalSuggestedEvent(suggestedBy, value, Id));
        }

        internal static Proposal Suggest(
            Money value,
            ProposalDescription description,
            EmployeeId estimatedBy)
        {
            return new(value, description, estimatedBy);
        }

        internal void Approve()
        {
            if (IsCancelled())
                throw new ProposalIsCancelledException(Id);
            if (HasDecision())
                throw new ProposalAlreadyHasDecisionException(Id);
            Decision = ProposalDecision.AcceptDecision(DateTime.Now);
        }

        internal void Reject(string rejectReason)
        {
            if (IsCancelled())
                throw new ProposalIsCancelledException(Id);

            if (HasDecision())
                throw new ProposalAlreadyHasDecisionException(Id);
            Decision = ProposalDecision.RejectDecision(DateTime.Now, rejectReason);
            AddDomainEvent(new ProposalRejectedEvent(rejectReason, Id));
        }

        internal void Cancel(EmployeeId employeeId)
        {
            if (IsCancelled())
                throw new ProposalAlreadyCancelledException(Id);

            Cancelled = DateTime.Now;
            CancelledBy = employeeId;
            AddDomainEvent(new ProposalCancelledEvent(employeeId, Id));
        }

        internal bool HasDecision()
        {
            return Decision != ProposalDecision.NoDecision;
        }

        internal bool IsCancelled()
        {
            return Cancelled.HasValue;
        }
    }
}
