namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using System;
using Assertions;
using Common;
using Domain.Valuations;
using Domain.Valuations.Exceptions;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using FluentAssertions;
using NUnit.Framework;
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
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
        valuation.RejectProposal(proposalId);

        var rejectProposal = () => valuation.RejectProposal(proposalId);

        rejectProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }
}
