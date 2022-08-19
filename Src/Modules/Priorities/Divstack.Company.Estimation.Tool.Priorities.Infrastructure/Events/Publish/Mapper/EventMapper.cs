namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish.Mapper;

using IntegrationsEvents.ExternalEvents;
using Shared.DDD.BuildingBlocks;
using Tool.Priorities.Domain.Events;

internal sealed class EventMapper : IEventMapper
{
    public List<IIntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events)
    {
        return events.Select(Map).Where(@event => @event is not null).ToList();
    }

    private static IIntegrationEvent? Map(IDomainEvent @event)
    {
        return @event switch
        {
            PriorityDefinedDomainEvent domainEvent =>
                new PriorityDefined(domainEvent.ValuationId.Value,
                    domainEvent.PriorityId.Value,
                    domainEvent.Deadline.Date),
            _ => null
        };
    }
}
