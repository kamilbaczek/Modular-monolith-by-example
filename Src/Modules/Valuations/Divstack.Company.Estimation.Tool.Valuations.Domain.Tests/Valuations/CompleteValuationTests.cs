namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

using System;
using Assertions;
using Common;
using Domain.Valuations;
using Domain.Valuations.Events;
using NUnit.Framework;

public class CompleteValuationTests : BaseValuationTest
{
    [Test]
    public void Given_Complete_When_ValuationHasAtLastOnceProposalWithDecision_Then_ValuationIsCompleted()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        var valuation = RequestFakeValuation();
        var proposalId = SuggestFakeProposal(employee, valuation);
        valuation.ApproveProposal(proposalId);

        valuation.Complete(employee);

        var @event = GetPublishedEvent<ValuationCompletedDomainEvent>(valuation);
        @event.AssertIsCorrect(employee, valuation.Id);
    }
}
