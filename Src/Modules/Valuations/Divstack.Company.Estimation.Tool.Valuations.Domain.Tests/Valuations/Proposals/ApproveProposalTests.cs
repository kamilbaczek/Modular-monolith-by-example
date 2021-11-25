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

public class ApproveProposalTests : BaseValuationTest
{
    [Test]
    public void Given_ApproveProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsApproved()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithEmployee(employeeId);
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        valuation.ApproveProposal(proposalSuggestedDomainEvent.ProposalId);

        var @event = GetPublishedEvent<ProposalApprovedDomainEvent>(valuation);
        @event.AssertIsCorrect(employeeId, proposalSuggestedDomainEvent.ProposalId);
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalIsCancelled_Then_ProposalIsNotFound()
    {
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithCancelledProposal();
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        var approveProposal = () => valuation.ApproveProposal(proposalSuggestedDomainEvent.ProposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
    {
        Valuation valuation = A.Valuation()
            .WithProposal();
        var proposalId = ProposalId.Create();

        var approveProposal = () => valuation.ApproveProposal(proposalId);

        approveProposal.Should().Throw<ProposalNotFoundException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotApproved()
    {
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithRejectedProposalDecision();
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        var approveProposal = () => valuation.ApproveProposal(proposalSuggestedDomainEvent.ProposalId);

        approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }

    [Test]
    public void Given_ApproveProposal_When_ProposalAlreadyApproved_Then_ProposalIsNotApproved()
    {
        Valuation valuation = A.Valuation()
            .WithProposal();
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();
        valuation.ApproveProposal(proposalSuggestedDomainEvent.ProposalId);

        var approveProposal = () => valuation.ApproveProposal(proposalSuggestedDomainEvent.ProposalId);

        approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
    }
}
