namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Proposals.Events;
using Domain.Valuations.Proposals.Exceptions;
using Domain.Valuations.States;
using Shared.DDD.ValueObjects;

public class SuggestProposalTests : BaseValuationTest
{
    [TestCase(100)]
    [TestCase(100.1)]
    [TestCase(2000.23)]
    [TestCase(1000000000)]
    [TestCase(99999999999999.9999)]
    public void Given_SuggestProposal_Then_SuggestProposal(decimal value)
    {
        var money = Money.Of(value, Currency);
        var employee = EmployeeId.Of(Id);
        ValuationRequested valuationRequested = A.Valuation();

        var valuationNegotiation = valuationRequested.SuggestProposal(money, Description, employee);

        var @event = GetPublishedEvent<ProposalSuggestedDomainEvent>(valuationNegotiation);
        @event.AssertIsCorrect(money, employee);
    }

    [TestCase(99.9)]
    [TestCase(50.9)]
    [TestCase(20.99)]
    [TestCase(1)]
    public void Given_SuggestProposal_When_ProposalValueIsLessenThanMinimal_Then_ThrowException(decimal value)
    {
        var money = Money.Of(value, Currency);
        var employee = EmployeeId.Of(Id);
        ValuationRequested valuationRequested = A.Valuation();

        var suggestProposal = () => valuationRequested.SuggestProposal(money, Description, employee);

        suggestProposal.Should().Throw<ProposalValueLessenThanMinimalException>();
    }

    [TestCase(99999999999999.9999,2)]
    public void Given_RejectProposal_When_ProposalIsNotCancelledAndHasNoDecision_Then_ProposalIsRejected(decimal value, int reproposalCount)
    {
        var money = Money.Of(value, Currency);
        var employee = EmployeeId.Of(Id);
        ValuationNegotiation valuationNegotiation = A.Valuation()
            .WithProposal()
            .WithReSuggestProposals(reproposalCount);

        var reSuggested = () => valuationNegotiation.ReSuggestProposal(money, Description, employee);
         
        //TODO change exception 
        reSuggested.Should().Throw<InvalidOperationException>();
    }
}
