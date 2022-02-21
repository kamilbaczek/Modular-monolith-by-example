namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Mapper;

using IntegrationsEvents;
using Shared.DDD.BuildingBlocks;
using Tool.Priorities.Domain.Events;

internal sealed class EventMapper : IEventMapper
{
    public IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events)
    {
        return events.Select(Map).ToList();
    }

    private static IntegrationEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            PriorityDefinedDomainEvent domainEvent =>
                new PriorityDefined(domainEvent.ValuationId.Value,
                    domainEvent.PriorityId.Value),
            _ => null
        };
    }
}
