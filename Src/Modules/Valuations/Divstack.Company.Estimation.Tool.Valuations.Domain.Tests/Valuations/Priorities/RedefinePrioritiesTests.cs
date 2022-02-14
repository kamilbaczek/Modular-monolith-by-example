namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Priorities;

using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Events;
using FluentAssertions;
using NUnit.Framework;
using Shared.DDD.BuildingBlocks;

public class RedefinePrioritiesTests : BaseValuationTest
{
    [Test]
    public void Given_RedefinePriorites_When_ValuationCloserToDeadline_Then_PriorityIncresed()
    {
        SystemTime.SetDateTime(new DateTime(2022, 01, 01));
        Valuation valuation = A.Valuation().WithDeadline(11);
        SystemTime.SetDateTime(new DateTime(2022, 01, 10));

        valuation.RedefinePriority(10);
        var @event = GetPublishedEvent<ValuationPrioritiesLevelIncresedDomainEvent>(valuation);
        @event.Should().NotBeNull();
    }

    [Test]
    public void Given_RedefinePriorites_When_ValuationDeadlineExceeded_Then_PriorityIncresed()
    {
        SystemTime.SetDateTime(new DateTime(2022, 01, 01));
        Valuation valuation = A.Valuation().WithDeadline(3);
        SystemTime.SetDateTime(new DateTime(2022, 03, 10));

        valuation.RedefinePriority(10);
        var @event = GetPublishedEvent<ValuationPrioritiesLevelIncresedDomainEvent>(valuation);
        @event.Should().NotBeNull();
    }
}
