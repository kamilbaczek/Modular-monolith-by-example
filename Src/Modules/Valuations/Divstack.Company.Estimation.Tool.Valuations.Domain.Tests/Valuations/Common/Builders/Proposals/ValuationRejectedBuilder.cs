namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals;

using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;

internal sealed class ValuationRejectedBuilder
{
    public ValuationRejectedBuilder(ValuationNegotiation valuation)
    {
        Valuation = valuation;
    } 
    
    private static ValuationNegotiation Valuation { get; set; }
    
    
    private static ValuationNegotiation RejectRecentProposal(ValuationNegotiation valuationNegotiation)
    {
        var recentProposal = valuationNegotiation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        valuationNegotiation.RejectProposal(recentProposal.ProposalId);

        return Valuation;
    }
    

    public static implicit operator ValuationNegotiation(ValuationRejectedBuilder builder) => RejectRecentProposal(Valuation);
}
