namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals.Decisions;

using Domain.Valuations;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;

internal sealed class ApprovedProposalBuilder
{
    public ApprovedProposalBuilder(ValuationNegotiation valuationNegotiation)
    {
        var proposalSuggestedDomainEvent = valuationNegotiation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        ProposalId = proposalSuggestedDomainEvent.ProposalId;
        ValuationNegotiation = valuationNegotiation;
    }
    private static ValuationNegotiation ValuationNegotiation { get; set; }
    private static ProposalId ProposalId { get; set; }

    public CompletedValuationBuilder MarkedAsComplete()
    {
       var approved =  Approve();

        return new CompletedValuationBuilder(approved);
    }

    private static ValuationApproved Approve()
    {
        var approved = ValuationNegotiation.ApproveProposal(ProposalId);

        return approved;
    }

    public static implicit operator ValuationApproved(ApprovedProposalBuilder builder)
    {
        return Approve();
    }
}
