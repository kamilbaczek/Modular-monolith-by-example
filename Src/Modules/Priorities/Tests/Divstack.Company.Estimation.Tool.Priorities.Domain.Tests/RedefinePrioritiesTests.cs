namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests;

using Common.Builders;
using Events;
using Shared.DDD.BuildingBlocks;

public class RedefinePrioritiesTests : BasePriorityTest
{
    private const int CompanySize = 1000;

    private static readonly object[] DatesTestCases =
    {
        new object[]
        {
            new DateTime(1998, 2, 6), 20, new DateTime(1998, 2, 26)
        },
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
    [TestCaseSource(nameof(DatesTestCases))]
    public void Given_Define_Then_DeadlineIsFixed(DateTime nowDate, int daysToDeadlineFromNow, DateTime expectedDeadline)
    {
        SystemTime.SetDateTime(nowDate);
        var deadline = A.Deadline().WithDeadline(daysToDeadlineFromNow);
        var inquiryId = InquiryId.Create();
        var valuationId = ValuationId.Create();

        var priority = Priority.Define(valuationId, inquiryId, CompanySize, deadline);

        var @event = GetPublishedEvent<PriorityDefinedDomainEvent>(priority);
        @event.Deadline.Date.Should().Be(expectedDeadline);
    }

    [Test]
    public void Given_Redefine_When_CloserToDeadline_Then_PriorityIncreased()
    {
        var currentDate = new DateTime(2022, 01, 01);
        SystemTime.SetDateTime(currentDate);
        Priority priority = A.Priority().WithCompanySize(CompanySize);
        SystemTime.SetDateTime(currentDate.AddDays(10));

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
