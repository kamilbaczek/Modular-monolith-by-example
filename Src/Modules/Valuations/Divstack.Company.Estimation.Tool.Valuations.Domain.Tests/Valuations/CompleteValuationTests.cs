﻿namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Events;
using Domain.Valuations.States;

public class CompleteValuationTests : BaseValuationTest
{
    [Test]
    public void Given_Complete_Then_ValuationIsCompleted()
    {
        var employee = new EmployeeId(Guid.NewGuid());
        ValuationApproved valuationApproved = A.Valuation()
            .WithProposal()
            .WithApprovedProposalDecision();

        var valuationCompleted = valuationApproved.Complete(employee);

        var @event = GetPublishedEvent<ValuationCompletedDomainEvent>(valuationCompleted);
        @event.AssertIsCorrect(valuationCompleted.ValuationId);
    }
}
