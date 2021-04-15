using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Proposals
{
    public class SuggestProposalTests : BaseValuationTest
    {
        [Fact]
        public async Task Given_SuggestProposal_Then_CannotSuggestProposal()
        {
            var valuation = await RequestFakeValuation();
            var money = Money.Of(30, "USD");
            var employee = new EmployeeId(Guid.NewGuid());

            valuation.SuggestProposal(money, "test", employee);

            var @event = GetPublishedEvent<ProposalSuggestedEvent>(valuation);
            @event.AssertIsCorrect(money, employee);
        }

        [Fact]
        public async Task Given_SuggestProposal_When_ValuationIsCompleted_Then_CannotSuggestProposal()
        {
            var valuation = await RequestFakeValuation();
            var money = Money.Of(30, "USD");
            var employee = new EmployeeId(Guid.NewGuid());
            var proposalId = SuggestFakeProposal(valuation, Money.Of(50, "USD"));
            valuation.ApproveProposal(proposalId);
            valuation.Complete(employee);

            Action suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

            suggestProposal.Should().Throw<ValuationCompletedException>();
        }

        [Fact]
        public async Task Given_SuggestProposal_When_ProposalHasNoDecision_Then_ProposalIsNotCreated()
        {
            var money = Money.Of(30, "USD");
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            SuggestFakeProposal(valuation);

            Action suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

            suggestProposal.Should().Throw<ProposalWaitForDecisionException>();
        }
    }
}
