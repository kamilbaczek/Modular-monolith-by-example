namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common.Builders.Proposals.Decisions;

using Domain.Valuations;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using Shared.DDD.BuildingBlocks.Tests;

internal sealed class RejectedProposalBuilder
{
    public RejectedProposalBuilder(Valuation valuation)
    {
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        ProposalId = proposalSuggestedDomainEvent.ProposalId;
        Valuation = valuation;
    }
    private static Valuation Valuation { get; set; }
    private static ProposalId ProposalId { get; set; }

    private static Valuation Rejected()
    {
        Valuation.RejectProposal(ProposalId);

        return Valuation;
    }

    public static implicit operator Valuation(RejectedProposalBuilder builder)
    {
        return Rejected();
    }
}
