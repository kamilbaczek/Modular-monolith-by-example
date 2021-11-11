using System;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

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
