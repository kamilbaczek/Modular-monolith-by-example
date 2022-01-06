namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

using Exceptions;
using Valuations.Exceptions;

public sealed class Proposal : Entity
{
    private Proposal(
        Money value,
        ProposalDescription description,
        EmployeeId suggestedBy)
    {
        Id = ProposalId.Create();
        Price = Guard.Against.Null(value, nameof(value));
        Description = Guard.Against.Null(description, nameof(description));
        SuggestedBy = Guard.Against.Null(suggestedBy, nameof(suggestedBy));
        Suggested = SystemTime.Now();
        Decision = ProposalDecision.NoDecision();
    }

    internal ProposalId Id { get; init; }
    private ProposalDescription Description { get; init; }
    internal Money Price { get; init; }
    internal EmployeeId SuggestedBy { get; init; }
    private DateTime Suggested { get; }
    private EmployeeId CancelledBy { get; set; }
    private DateTime? Cancelled { get; set; }
    private ProposalDecision Decision { get; set; }

    internal bool HasDecision => Decision != ProposalDecision.NoDecision();
    internal bool IsCancelled => Cancelled.HasValue;

    internal static Proposal Suggest(
        Money value,
        ProposalDescription description,
        EmployeeId proposedBy)
    {
        return new Proposal(value, description, proposedBy);
    }

    internal void Approve()
    {
        if (IsCancelled)
        {
            throw new ProposalIsCancelledException(Id);
        }

        if (HasDecision)
        {
            throw new ProposalAlreadyHasDecisionException(Id);
        }

        Decision = ProposalDecision.AcceptDecision(DateTime.Now);
    }

    internal void Reject()
    {
        if (IsCancelled)
        {
            throw new ProposalIsCancelledException(Id);
        }

        if (HasDecision)
        {
            throw new ProposalAlreadyHasDecisionException(Id);
        }

        Decision = ProposalDecision.RejectDecision(DateTime.Now);
    }

    internal void Cancel(EmployeeId employeeId)
    {
        if (IsCancelled)
        {
            throw new ProposalAlreadyCancelledException(Id);
        }

        Cancelled = DateTime.Now;
        CancelledBy = employeeId;
    }
}
