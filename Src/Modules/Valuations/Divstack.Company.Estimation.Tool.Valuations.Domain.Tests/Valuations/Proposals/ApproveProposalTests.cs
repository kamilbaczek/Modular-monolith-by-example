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

public class ApproveProposalTests : BaseValuationTest
{
    [Test]
    public void Given_ApproveProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsApproved()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employeeId, valuation);

        valuation.ApproveProposal(proposalId);

        var @event = GetPublishedEvent<ProposalApprovedDomainEvent>(valuation);
        @event.AssertIsCorrect(employeeId, proposalId);
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalIsCancelled_Then_ProposalIsNotFound()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
        valuation.CancelProposal(proposalId, employee);

        var approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
    {
        var valuation = RequestFakeValuation();
        var proposalId = new ProposalId(Guid.NewGuid());

        var approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotApproved()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
        valuation.RejectProposal(proposalId);

        var approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalAlreadyApproved_Then_ProposalIsNotApproved()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation);
        valuation.ApproveProposal(proposalId);

        var approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }
}
