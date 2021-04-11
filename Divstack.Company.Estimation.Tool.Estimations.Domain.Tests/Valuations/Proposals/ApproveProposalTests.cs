using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Proposals
{
    public class ApproveProposalTests : BaseValuationTest
    {
        [Fact]
        public async Task Given_ApproveProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsApproved()
        {
            var fakeClientEmail = Email.Of("test@mail.com");
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(valuation);

            valuation.ApproveProposal(proposalId);

            var @event = GetPublishedEvent<ProposalApprovedEvent>(valuation);
            @event.AssertIsCorrect(fakeClientEmail, proposalId);
        }

        [Fact]
        public async Task Given_ApproveProposal_When_ProposalIsCancelled_Then_ProposalIsNotFound()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(valuation, Money.Of(50, "USD"));
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
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(valuation, Money.Of(50, "USD"));
            valuation.RejectProposal(proposalId, "test reason");

            Action approveProposal = () => valuation.ApproveProposal(proposalId);

            approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
        }

        [Fact]
        public async Task Given_ApproveProposal_When_ProposalAlreadyApproved_Then_ProposalIsNotApproved()
        {
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(valuation);
            valuation.ApproveProposal(proposalId);

            Action approveProposal = () => valuation.ApproveProposal(proposalId);

            approveProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
        }
    }
}
