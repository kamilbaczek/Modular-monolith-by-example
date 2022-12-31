namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.States;
using Shared.DDD.BuildingBlocks.Tests;

public class RejectProposalTests : BaseValuationTest
{
    [Test]
    public void Given_RejectProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsRejected()
    {
        ValuationNegotiation valuation = A.Valuation()
            .WithProposal();
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        valuation.RejectProposal(proposalSuggestedDomainEvent.ProposalId);

        var @event = GetPublishedEvent<ProposalRejectedDomainEvent>(valuation);
        @event.AssertIsCorrect(proposalSuggestedDomainEvent.ProposalId, valuation.ValuationId);
    }


    
    //
    // [Test]
    // public void Given_RejectProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
    // {
    //     Valuation valuation = A.Valuation()
    //         .WithProposal();
    //     var proposalId = new ProposalId(Guid.NewGuid());
    //
    //     var rejectProposal = () => valuation.RejectProposal(proposalId);
    //
    //     rejectProposal.Should().Throw<ProposalNotFoundException>();
    // }
    //
    // [Test]
    // public void Given_RejectProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotRejected()
    // {
    //     Valuation valuation = A.Valuation()
    //         .WithProposal()
    //         .WithRejectedProposalDecision();
    //     var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
    //
    //     var rejectProposal = () => valuation.RejectProposal(proposalSuggestedDomainEvent.ProposalId);
    //
    //     rejectProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    // }
}
