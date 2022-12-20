namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals;

using Decisions;
using Domain.Valuations;
using Domain.Valuations.States;
using Shared.DDD.ValueObjects;

internal sealed class ProposalSuggestionBuilder
{
    public ProposalSuggestionBuilder(ValuationRequested valuation)
    {
        Value = Money.Of(3123, "USD");
        Description = "test";
        ProposedBy = EmployeeId.Of(Guid.NewGuid());
        Valuation = valuation;
    }
    private static ValuationRequested Valuation { get; set; }
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

    internal ApprovedProposalBuilder WithApprovedProposalDecision()
    {
        var valuationNegotiation = Suggest();
        return new ApprovedProposalBuilder(valuationNegotiation);
    }

    // internal RejectedProposalBuilder WithRejectedProposalDecision()
    // {
    //     Suggest();
    //     return new RejectedProposalBuilder(Valuation);
    // }
    //
    // internal ProposalCancelledBuilder WithCancelledProposal()
    // {
    //     Suggest();
    //     return new ProposalCancelledBuilder(Valuation);
    // }

    private static ValuationNegotiation Suggest()
    {
        var valuationNegotiation = Valuation.SuggestProposal(Value, Description, ProposedBy);

        return valuationNegotiation;
    }

    public static implicit operator ValuationNegotiation(ProposalSuggestionBuilder builder)
    {
        return Suggest();
    }
}
