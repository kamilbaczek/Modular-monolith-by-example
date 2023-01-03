namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

using Exceptions;

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
        Price = Guard.Against.Null(value);
        Description = Guard.Against.Null(description);
        SuggestedBy = Guard.Against.Null(suggestedBy);
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
        var now = SystemTime.Now();
        Decision = ProposalDecision.AcceptDecision(now);
    }

    internal void Reject()
    {
        if (IsCancelled)
            throw new ProposalIsCancelledException(Id);

        Decision = ProposalDecision.RejectDecision(DateTime.Now);
    }

    internal void Cancel(EmployeeId employeeId)
    {
        Cancelled = SystemTime.Now();
        CancelledBy = employeeId;
    }
}
