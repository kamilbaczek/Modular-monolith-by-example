using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

public class RequestValuationTests : BaseValuationTest
{
    private static object[] _datesTestCases =
    {
            new object[] {new DateTime(1998, 2, 3), 3, new DateTime(1998, 2, 6)},
            new object[] {new DateTime(2021, 6, 25), 2, new DateTime(2021, 6, 27)}
        };

    [Test]
    public void Given_Request_Then_ValuationIsCreated()
    {
        var deadline = FakeDeadline.CreateDeadline();
        var inquiry = InquiryId.Create();

        var valuation = Valuation.Request(inquiry, deadline);

        var @event = GetPublishedEvent<ValuationRequestedDomainEvent>(valuation);
        @event.AssertIsCorrect();
    }

    [Test]
    [TestCaseSource(nameof(_datesTestCases))]
    public void Given_Request_Then_DeadlineIsFixed(DateTime nowDate, int daysToDeadlineFromNow,
        DateTime expectedDeadline)
    {
        SystemTime.SetDateTime(nowDate);
        var deadline = FakeDeadline.CreateDeadline(daysToDeadlineFromNow);
        var inquiry = InquiryId.Create();

        var valuation = Valuation.Request(inquiry, deadline);

        var @event = GetPublishedEvent<ValuationRequestedDomainEvent>(valuation);
        @event.DeadlineDate.Should().Be(expectedDeadline);
    }
}
