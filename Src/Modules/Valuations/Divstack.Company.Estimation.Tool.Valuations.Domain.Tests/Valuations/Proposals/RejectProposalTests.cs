namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Exceptions;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using FluentAssertions;
using NUnit.Framework;
using Shared.DDD.BuildingBlocks.Tests;
using Shared.DDD.ValueObjects;

public class RejectProposalTests : BaseValuationTest
{
    [Test]
    public void Given_RejectProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsRejected()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation);

        valuation.RejectProposal(proposalId);

        var @event = GetPublishedEvent<ProposalRejectedDomainEvent>(valuation);
        @event.AssertIsCorrect(proposalId, valuation.Id);
    }

    [Test]
    public void Given_RejectProposal_When_ProposalIsCancelled_Then_ProposalIsNotFound()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
        valuation.CancelProposal(proposalId, employee);

        var rejectProposal = () => valuation.RejectProposal(proposalId);

        rejectProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_RejectProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
    {
        var valuation = RequestFakeValuation();
        var proposalId = new ProposalId(Guid.NewGuid());

        var rejectProposal = () => valuation.RejectProposal(proposalId);

        rejectProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_RejectProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotRejected()
    {
        Valuation valuation = A.Valuation()
            .WithProposal();
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        valuation.RejectProposal(proposalSuggestedDomainEvent.ProposalId);

        var rejectProposal = () => valuation.RejectProposal(proposalSuggestedDomainEvent.ProposalId);

        rejectProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }
}
