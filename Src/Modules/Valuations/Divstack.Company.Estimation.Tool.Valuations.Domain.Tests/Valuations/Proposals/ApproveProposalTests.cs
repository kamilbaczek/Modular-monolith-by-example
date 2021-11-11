using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

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

        Action approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
    {
        var valuation = RequestFakeValuation();
        var proposalId = new ProposalId(Guid.NewGuid());

        Action approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotApproved()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
        valuation.RejectProposal(proposalId);

        Action approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalAlreadyApproved_Then_ProposalIsNotApproved()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation);
        valuation.ApproveProposal(proposalId);

        Action approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }
}
