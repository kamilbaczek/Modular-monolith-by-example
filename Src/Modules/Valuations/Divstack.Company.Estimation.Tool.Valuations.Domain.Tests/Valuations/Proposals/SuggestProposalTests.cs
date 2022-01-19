namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Exceptions;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.Proposals.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using Shared.DDD.ValueObjects;

public class SuggestProposalTests : BaseValuationTest
{
    private const decimal MinimumSuggestionValue = 100;

    [TestCase(100)]
    [TestCase(100.1)]
    [TestCase(2000.23)]
    [TestCase(1000000000)]
    [TestCase(99999999999999.9999)]
    public void Given_SuggestProposal_Then_SuggestProposal(decimal value)
    {
        var money = Money.Of(value, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation();

        valuation.SuggestProposal(money, "test", employee);

        var @event = GetPublishedEvent<ProposalSuggestedDomainEvent>(valuation);
        @event.AssertIsCorrect(money, employee);
    }

    [Test]
    public void Given_SuggestProposal_When_ValuationIsCompleted_Then_CannotSuggestProposal()
    {
        var money = Money.Of(MinimumSuggestionValue, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithApprovedProposalDecision()
            .MarkedAsComplete();

        var suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

        suggestProposal.Should().Throw<ValuationCompletedException>();
    }

    [Test]
    public void Given_SuggestProposal_When_ProposalHasNoDecision_Then_ProposalIsNotCreated()
    {
        var money = Money.Of(MinimumSuggestionValue, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal();

        var suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

        suggestProposal.Should().Throw<ProposalWaitForDecisionException>();
    }

    [TestCase(99.9)]
    [TestCase(50.9)]
    [TestCase(20.99)]
    [TestCase(1)]
    public void Given_SuggestProposal_When_ProposalValueIsLessenThanMinimal_Then_ThrowException(decimal value)
    {
        var money = Money.Of(value, "USD");
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation();

        var suggestProposal = () => valuation.SuggestProposal(money, "test", employee);

        suggestProposal.Should().Throw<ProposalValueLessenThanMinimalException>();
    }
}
