using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
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
    public class RejectProposalTests : BaseValuationTest
    {
        [Fact]
        public async Task Given_RejectProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsRejected()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var fakeEmail = Email.Of("test@mail.com");
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employee, valuation);

            valuation.RejectProposal(proposalId);

            var @event = GetPublishedEvent<ProposalRejectedEvent>(valuation);
            @event.AssertIsCorrect(fakeEmail, proposalId, FakeRejectReason);
        }

        [Fact]
        public async Task Given_RejectProposal_When_ProposalIsCancelled_Then_ProposalIsNotFound()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
            valuation.CancelProposal(proposalId, employee);

            Action rejectProposal = () => valuation.RejectProposal(proposalId);

            rejectProposal.Should().Throw<ProposalNotFoundException>();
        }

        [Fact]
        public async Task Given_RejectProposal_When_ProposalNotExist_Then_ProposalIsNotFound()
        {
            var valuation = await RequestFakeValuation();
            var proposalId = new ProposalId(Guid.NewGuid());

            Action rejectProposal = () => valuation.RejectProposal(proposalId);

            rejectProposal.Should().Throw<ProposalNotFoundException>();
        }

        [Fact]
        public async Task Given_RejectProposal_When_ProposalAlreadyRejected_Then_ProposalIsNotRejected()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(employee, valuation, Money.Of(50, "USD"));
            valuation.RejectProposal(proposalId);

            Action rejectProposal = () => valuation.RejectProposal(proposalId);

            rejectProposal.Should().Throw<ProposalAlreadyHasDecisionException>();
        }
    }
}
