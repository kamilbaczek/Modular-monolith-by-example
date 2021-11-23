namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals.Decisions;

using Domain.Valuations;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using Shared.DDD.BuildingBlocks.Tests;

internal sealed class ApprovedProposalBuilder
{
    public ApprovedProposalBuilder(Valuation valuation)
    {
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        ProposalId = proposalSuggestedDomainEvent.ProposalId;
        Valuation = valuation;
    }
    private static Valuation Valuation { get; set; }
    private static ProposalId ProposalId { get; set; }

    public CompletedValuationBuilder MarkedAsComplete()
    {
        Approve();

        return new CompletedValuationBuilder(Valuation);
    }

    private static Valuation Approve()
    {
        Valuation.ApproveProposal(ProposalId);

        return Valuation;
    }

    public static implicit operator Valuation(ApprovedProposalBuilder builder)
    {
        return Approve();
    }
}
