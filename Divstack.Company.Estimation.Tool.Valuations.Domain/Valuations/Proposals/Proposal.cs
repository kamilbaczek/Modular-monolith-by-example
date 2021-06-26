using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals
{
    public sealed class Proposal : Entity
    {
        private Proposal()
        {
        }

        private Proposal(
            Valuation valuation,
            Money value,
            ProposalDescription description,
            EmployeeId suggestedBy)
        {
            Id = new ProposalId(Guid.NewGuid());
            Price = value ?? throw new ArgumentNullException(nameof(value));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            SuggestedBy = suggestedBy ?? throw new ArgumentNullException(nameof(suggestedBy));
            Suggested = DateTime.Now;
            Decision = null;
            Valuation = valuation;
        }

        internal ProposalId Id { get; }
        private ProposalDescription Description { get; }
        internal Money Price { get; }
        internal EmployeeId SuggestedBy { get; }
        private DateTime Suggested { get; }
        private EmployeeId CancelledBy { get; set; }
        private DateTime? Cancelled { get; set; }
        private ProposalDecision Decision { get; set; }
        private Valuation Valuation { get; }

        internal static Proposal Suggest(
            Valuation valuation,
            Money value,
            ProposalDescription description,
            EmployeeId proposedBy)
        {
            return new(valuation, value, description, proposedBy);
        }

        internal void Approve()
        {
            if (IsCancelled())
                throw new ProposalIsCancelledException(Id);
            if (HasDecision())
                throw new ProposalAlreadyHasDecisionException(Id);
            Decision = ProposalDecision.AcceptDecision(DateTime.Now);
        }

        internal void Reject()
        {
            if (IsCancelled())
                throw new ProposalIsCancelledException(Id);

            if (HasDecision())
                throw new ProposalAlreadyHasDecisionException(Id);
            Decision = ProposalDecision.RejectDecision(DateTime.Now);
        }

        internal void Cancel(EmployeeId employeeId)
        {
            if (IsCancelled())
                throw new ProposalAlreadyCancelledException(Id);

            Cancelled = DateTime.Now;
            CancelledBy = employeeId;
        }

        internal bool HasDecision()
        {
            return Decision is not null;
        }

        internal bool IsCancelled()
        {
            return Cancelled.HasValue;
        }
    }
}