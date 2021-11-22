namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals;

using Decisions;
using Domain.Valuations;
using Shared.DDD.ValueObjects;

internal sealed class ProposalSuggestionBuilder
{
    public ProposalSuggestionBuilder(Valuation valuation)
    {
        Value = Money.Of(3123, "USD");
        Description = "test";
        ProposedBy = EmployeeId.Of(Guid.NewGuid());
        Valuation = valuation;
    }
    private static Valuation Valuation { get; set; }
    private static Money Value { get; set; }
    private static string Description { get; set; }
    private static EmployeeId ProposedBy { get; set; }

    internal ProposalSuggestionBuilder WithPrice(Money value)
    {
        Value = value;
        return this;
    }

    internal ProposalSuggestionBuilder WithEmployee(EmployeeId proposedBy)
    {
        ProposedBy = proposedBy;
        return this;
    }

    internal ProposalSuggestionBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }

    internal ProposalSuggestionBuilder WithProposedBy(EmployeeId proposedBy)
    {
        ProposedBy = proposedBy;
        return this;
    }

    internal ApprovedProposalBuilder WithApprovedProposalDecision()
    {
        Suggest();
        return new ApprovedProposalBuilder(Valuation);
    }

    internal RejectedProposalBuilder WithRejectedProposalDecision()
    {
        Suggest();
        return new RejectedProposalBuilder(Valuation);
    }

    internal ProposalCancelledBuilder WithCancelledProposal()
    {
        return new ProposalCancelledBuilder(Valuation);
    }

    private static Valuation Suggest()
    {
        Valuation.SuggestProposal(Value, Description, ProposedBy);

        return Valuation;
    }

    public static implicit operator Valuation(ProposalSuggestionBuilder builder)
    {
        return Suggest();
    }
}
