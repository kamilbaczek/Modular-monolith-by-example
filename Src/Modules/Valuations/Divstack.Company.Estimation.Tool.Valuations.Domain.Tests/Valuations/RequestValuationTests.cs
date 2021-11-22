namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

using Assertions;
using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Events;
using FluentAssertions;
using NUnit.Framework;
using Shared.DDD.BuildingBlocks;

public class RequestValuationTests : BaseValuationTest
{
    private static object[] _datesTestCases =
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
    public void Given_Request_Then_ValuationIsCreated()
    {
        const int worksDaysToDeadlineFromNow = 5;
        var deadline = A.Deadline().WithDeadline(worksDaysToDeadlineFromNow);
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
        var deadline = A.Deadline().WithDeadline(daysToDeadlineFromNow);
        var inquiry = InquiryId.Create();

        var valuation = Valuation.Request(inquiry, deadline);

        var @event = GetPublishedEvent<ValuationRequestedDomainEvent>(valuation);
        @event.DeadlineDate.Should().Be(expectedDeadline);
    }
}
