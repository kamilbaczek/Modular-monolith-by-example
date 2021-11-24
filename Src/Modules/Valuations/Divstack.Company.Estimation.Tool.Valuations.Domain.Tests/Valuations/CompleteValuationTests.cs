namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Events;
using NUnit.Framework;

public class CompleteValuationTests : BaseValuationTest
{
    [Test]
    public void Given_Complete_When_ValuationHasAtLastOnceProposalWithDecision_Then_ValuationIsCompleted()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithApprovedProposalDecision();

        valuation.Complete(employee);

        var @event = GetPublishedEvent<ValuationCompletedDomainEvent>(valuation);
        @event.AssertIsCorrect(valuation.Id);
    }
}
