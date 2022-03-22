namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests;

using Common.Builders;
using Events;
using FluentAssertions;
using NUnit.Framework;

public class ForceTests : BasePriorityTest
{
    [Test]
    public void Given_Force_Then_CalculatedPriorityIsIgnored()
    {
        Priority priority = A.Priority().WithCompanySize(10);
        var level = new PriorityLevel("test", 1, 1);

        priority.Force(level);

        var @event = GetPublishedEvent<PriorityForcedDomainEvent>(priority);
        @event.Should().NotBeNull();
        @event.Level.Name.Should().Be(level.Name);
        @event.Level.Scores.Should().Be(level.Scores);
        @event.Level.Weight.Should().Be(level.Weight);
    }
}
