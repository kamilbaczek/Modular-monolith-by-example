#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

using Exceptions;
using Valuations.Exceptions;

public sealed class Proposal : Entity
{
    private Proposal()
    {
    }

    private Proposal(
        ProposalId proposalId,
        Money value,
        ProposalDescription description,
        EmployeeId suggestedBy)
    {
        Id = proposalId;
        Price = Guard.Against.Null(value, nameof(value));
        Description = Guard.Against.Null(description, nameof(description));
        SuggestedBy = Guard.Against.Null(suggestedBy, nameof(suggestedBy));
        Suggested = SystemTime.Now();
        Decision = ProposalDecision.NoDecision();
    }

    public ProposalId Id { get; init; }
    public ProposalDescription Description { get; init; }
    public Money Price { get; init; }
    public EmployeeId SuggestedBy { get; init; }
    private DateTime Suggested { get; }
    public EmployeeId CancelledBy { get; set; }
    private DateTime? Cancelled { get; set; }
    private ProposalDecision Decision { get; set; }

    internal bool HasDecision => Decision != ProposalDecision.NoDecision();
    internal bool IsCancelled => Cancelled.HasValue;

    private static Money MinimumProposalValue => Money.Of(100, "USD");

    internal static Proposal Suggest(
        ProposalId proposalId,
        Money value,
        ProposalDescription description,
        EmployeeId proposedBy)
    {
        if (value < MinimumProposalValue)
            throw new ProposalValueLessenThanMinimalException(value, MinimumProposalValue);
        return new Proposal(proposalId, value, description, proposedBy);
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

        Cancelled = SystemTime.Now();
        CancelledBy = employeeId;
    }
}
