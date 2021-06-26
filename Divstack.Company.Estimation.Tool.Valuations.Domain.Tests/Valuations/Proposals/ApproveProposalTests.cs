using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals
{
    public class ApproveProposalTests : BaseValuationTest
    {
        [Fact]
        public async Task Given_ApproveProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsApproved()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employeeId, valuation);

            valuation.ApproveProposal(proposalId);

            var @event = GetPublishedEvent<ProposalApprovedEvent>(valuation);
            @event.AssertIsCorrect(employeeId, proposalId);
        }

        [Fact]
        public async Task Given_ApproveProposal_When_ProposalIsCancelled_Then_ProposalIsNotFound()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
            valuation.CancelProposal(proposalId, employee);

            Action approveProposal = () => valuation.ApproveProposal(proposalId);

            approveProposal.Should().Throw<ProposalNotFoundException>();
        }

        [Fact]
        public async Task Given_ApproveProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
        {
            var valuation = await RequestFakeValuation();
            var proposalId = new ProposalId(Guid.NewGuid());

            Action approveProposal = () => valuation.ApproveProposal(proposalId);

            approveProposal.Should().Throw<ProposalNotFoundException>();
        }

        [Fact]
        public async Task Given_ApproveProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotApproved()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
            valuation.RejectProposal(proposalId);

            Action approveProposal = () => valuation.ApproveProposal(proposalId);

            approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
        }

        [Fact]
        public async Task Given_ApproveProposal_When_ProposalAlreadyApproved_Then_ProposalIsNotApproved()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employee, valuation);
            valuation.ApproveProposal(proposalId);

            Action approveProposal = () => valuation.ApproveProposal(proposalId);

            approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
        }
    }
}