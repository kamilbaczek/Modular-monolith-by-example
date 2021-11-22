namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Exceptions;
using Domain.Valuations.Proposals.Events;
using FluentAssertions;
using NUnit.Framework;
using Shared.DDD.ValueObjects;

public class SuggestProposalTests : BaseValuationTest
{
    [Test]
    public void Given_SuggestProposal_Then_SuggestProposal()
    {
        var money = Money.Of(30, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation();

        valuation.SuggestProposal(money, "test", employee);

        var @event = GetPublishedEvent<ProposalSuggestedDomainEvent>(valuation);
        @event.AssertIsCorrect(money, employee);
    }

    [Test]
    public void Given_SuggestProposal_When_ValuationIsCompleted_Then_CannotSuggestProposal()
    {
        var money = Money.Of(30, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithApprovedProposalDecision()
            .Completed();

        var suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

        suggestProposal.Should().Throw<ValuationCompletedException>();
    }

    [Test]
    public void Given_SuggestProposal_When_ProposalHasNoDecision_Then_ProposalIsNotCreated()
    {
        var money = Money.Of(30, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal();

        var suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

        suggestProposal.Should().Throw<ProposalWaitForDecisionException>();
    }
}
