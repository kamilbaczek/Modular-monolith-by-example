namespace Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.Tests;

using System.Linq;
using FluentAssertions;

public abstract class BaseTest
{
    protected static TEvent GetPublishedEvent<TEvent>(Entity entity) where TEvent : class,
        IDomainEvent =>
        entity.DomainEvents.OfType<TEvent>()
                           .MinBy(domainEvent => domainEvent.OccurredOn);

    protected static void AssertEventNotPublished<TEvent>(Entity entity) where TEvent : class
    {
        entity.DomainEvents.OfType<TEvent>()
                    .FirstOrDefault()
                    .Should()
                    .BeNull();
    }

    protected static void AssertEventNotTwicePublished<TEvent>(Entity entity) where TEvent : class
    {
        entity.DomainEvents.OfType<TEvent>().Skip(1)
            .FirstOrDefault().Should().BeNull();
    }
}
