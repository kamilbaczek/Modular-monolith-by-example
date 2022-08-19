﻿namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests;

using System;
using Common.Builders;
using Events;
using FluentAssertions;
using NUnit.Framework;
using Shared.DDD.BuildingBlocks;

public class RedefinePrioritiesTests : BasePriorityTest
{
    private const int CompanySize = 1000;

    private static readonly object[] _datesTestCases =
    {
        new object[]
        {
            new DateTime(1998, 2, 3), 3, new DateTime(1998, 2, 6)
        },
        new object[]
        {
            new DateTime(2021, 6, 25), 2, new DateTime(2021, 6, 27)
        }
    };

    [Test]
    [TestCaseSource(nameof(_datesTestCases))]
    public void Given_Define_Then_DeadlineIsFixed(DateTime nowDate, int daysToDeadlineFromNow, DateTime expectedDeadline)
    {
        SystemTime.SetDateTime(nowDate);
        var deadline = A.Deadline().WithDeadline(daysToDeadlineFromNow);
        var inquiryId = InquiryId.Create(new Guid());
        var valuationId = ValuationId.Create(new Guid());

        var priority = Priority.Define(valuationId, inquiryId, CompanySize, deadline);

        var @event = GetPublishedEvent<PriorityDefinedDomainEvent>(priority);
        @event.Deadline.Date.Should().Be(expectedDeadline);
    }

    [Test]
    public void Given_Redefine_When_CloserToDeadline_Then_PriorityIncreased()
    {
        SystemTime.SetDateTime(new DateTime(2022, 01, 01));
        Priority priority = A.Priority().WithCompanySize(CompanySize);
        SystemTime.SetDateTime(new DateTime(2022, 01, 10));

        priority.Redefine(CompanySize);

        var @event = GetPublishedEvent<PriorityIncreasedDomainEvent>(priority);
        @event.Should().NotBeNull();
    }

    [Test]
    public void Given_Redefine_When_ValuationDeadlineExceeded_Then_PriorityIncreased()
    {
        SystemTime.SetDateTime(new DateTime(2022, 01, 01));
        Priority priority = A.Priority();
        SystemTime.SetDateTime(new DateTime(2022, 03, 10));

        priority.Redefine(CompanySize);

        var @event = GetPublishedEvent<PriorityIncreasedDomainEvent>(priority);
        @event.Should().NotBeNull();
    }
}
