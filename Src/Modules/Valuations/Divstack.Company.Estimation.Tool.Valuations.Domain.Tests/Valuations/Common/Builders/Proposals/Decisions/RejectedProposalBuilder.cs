namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals.Decisions;

using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;

internal sealed class RejectedProposalBuilder
{
    private static ValuationNegotiation ValuationNegotiation { get; set; }
    private static ProposalId ProposalId { get; set; }

    public RejectedProposalBuilder(ValuationNegotiation valuationNegotiation)
    {
        var proposalSuggestedDomainEvent = valuationNegotiation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        ProposalId = proposalSuggestedDomainEvent.ProposalId;
        ValuationNegotiation = valuationNegotiation;
    }

    private static ValuationNegotiation Rejected()
    {
        ValuationNegotiation.RejectProposal(ProposalId);

        return ValuationNegotiation;
    }

    public static implicit operator ValuationNegotiation(RejectedProposalBuilder builder) =>
        Rejected();
}
