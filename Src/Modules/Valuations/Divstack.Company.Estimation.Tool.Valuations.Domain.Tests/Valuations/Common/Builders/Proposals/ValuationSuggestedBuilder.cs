namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals;

using Bogus;
using Decisions;
using Domain.Valuations;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;
using Shared.DDD.ValueObjects;

internal sealed class ValuationSuggestedBuilder
{
    private readonly Faker _faker = new();

    public ValuationSuggestedBuilder(ValuationRequested valuation)
    {
        Value = CreateFakeValue();
        Description = _faker.Lorem.Sentence();
        ProposedBy = EmployeeId.Of(Guid.NewGuid());
        Valuation = valuation;
    } 
   
    private Money CreateFakeValue() => 
        Money.Of(_faker.Finance.Amount(101), _faker.Finance.Currency().Code);

    private static ValuationRequested Valuation { get; set; }
    private static Money Value { get; set; }
    private static string Description { get; set; }
    private static EmployeeId ProposedBy { get; set; }

    internal ValuationSuggestedBuilder WithPrice(Money value)
    {
        Value = value;
        
        return this;
    }

    internal ValuationSuggestedBuilder WithEmployee(EmployeeId proposedBy)
    {
        ProposedBy = proposedBy;
        
        return this;
    }

    internal ValuationSuggestedBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }
    
    internal ValuationSuggestedBuilder WithReSuggestProposals(int reSuggestedProposalCount)
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
    
    internal ValuationRejectedBuilder WithRejected()
    {
        var valuationNegotiation = Suggest();

        return new ValuationRejectedBuilder(valuationNegotiation);
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

    public static implicit operator ValuationNegotiation(ValuationSuggestedBuilder builder) => Suggest();
}
