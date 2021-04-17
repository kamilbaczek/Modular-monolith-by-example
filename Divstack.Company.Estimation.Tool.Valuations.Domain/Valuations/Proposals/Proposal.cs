using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals
{
    public sealed class Proposal : Entity
    {
        internal ProposalId Id { get; }
        private ProposalDescription Description { get; }
        private Money Price { get; }
        private EmployeeId SuggestedBy { get; }
        private DateTime Suggested { get; }
        private EmployeeId CancelledBy { get; set; }
        private DateTime? Cancelled { get; set; }
        private ProposalDecision Decision { get; set; }
        private Valuation Valuation { get; }

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
            Description = description ?? throw new ArgumentNullException(nameof(description));;
            SuggestedBy = suggestedBy ?? throw new ArgumentNullException(nameof(suggestedBy));
            Suggested = DateTime.Now;
            Decision = ProposalDecision.NoDecision;
            Valuation = valuation;
        }

        internal static Proposal Suggest(
            Valuation valuation,
            Money value,
            ProposalDescription description,
            EmployeeId estimatedBy)
        {
            return new(valuation, value, description, estimatedBy);
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
            return Decision != ProposalDecision.NoDecision;
        }

        internal bool IsCancelled()
        {
            return Cancelled.HasValue;
        }
    }
}
