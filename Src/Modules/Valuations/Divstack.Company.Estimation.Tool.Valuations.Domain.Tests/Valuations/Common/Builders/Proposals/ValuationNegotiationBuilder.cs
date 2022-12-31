namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals;

using Bogus;
using Decisions;
using Domain.Valuations;
using Domain.Valuations.Events;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;
using Shared.DDD.ValueObjects;

internal sealed class ValuationNegotiationBuilder
{
    private readonly Faker _faker = new();

    public ValuationNegotiationBuilder(ValuationRequested valuation)
    {
        Value = CreateFakeValue();
        Description = _faker.Lorem.Sentence();
        ProposedBy = EmployeeId.Of(Guid.NewGuid());
        Valuation = valuation;
    }
    private Money CreateFakeValue()
    {
        return Money.Of(_faker.Finance.Amount(101), _faker.Finance.Currency().Code);
    }
    private static ValuationRequested Valuation { get; set; }
    private static Money Value { get; set; }
    private static string Description { get; set; }
    private static EmployeeId ProposedBy { get; set; }

    internal ValuationNegotiationBuilder WithPrice(Money value)
    {
        Value = value;
        return this;
    }

    internal ValuationNegotiationBuilder WithEmployee(EmployeeId proposedBy)
    {
        ProposedBy = proposedBy;
        return this;
    }

    internal ValuationNegotiationBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }
    
    internal ValuationNegotiationBuilder WithReSuggestProposals(int reSuggestedProposalCount)
    {
        var valuationNegotiation = Suggest();
        RejectRecentProposal(valuationNegotiation);

        for (var i = 0; i < reSuggestedProposalCount; i++)
        {
            var value = CreateFakeValue();
            valuationNegotiation.ReSuggestProposal(value, Description, ProposedBy);
            RejectRecentProposal(valuationNegotiation);
        }
        
        return this;
    }
    private static void RejectRecentProposal(ValuationNegotiation valuationNegotiation)
    {
        var recentProposal = valuationNegotiation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        valuationNegotiation.RejectProposal(recentProposal.ProposalId);
    }

    internal ApprovedProposalBuilder WithApprovedProposalDecision()
    {
        var valuationNegotiation = Suggest();
        return new ApprovedProposalBuilder(valuationNegotiation);
    }
    
    private static ValuationNegotiation Suggest()
    {
        var valuationNegotiation = Valuation.SuggestProposal(Value, Description, ProposedBy);

        return valuationNegotiation;
    }

    public static implicit operator ValuationNegotiation(ValuationNegotiationBuilder builder)
    {
        return Suggest();
    }
}
