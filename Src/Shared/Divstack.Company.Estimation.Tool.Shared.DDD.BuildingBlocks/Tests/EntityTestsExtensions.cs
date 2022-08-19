namespace Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.Tests;

using System.Linq;

public static class EntityTestsExtensions
{
    public static TEvent GetPublishedEvent<TEvent>(this Entity entity) where TEvent : class,
        IDomainEvent
    {
        return entity.DomainEvents.OfType<TEvent>()
            .OrderBy(domainEvent => domainEvent.OccurredOn)
            .FirstOrDefault();
    }
}
