namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish;

using Common.Interfaces;
using Configuration;
using Mapper;
using Shared.DDD.BuildingBlocks;
using Shared.Infrastructure.EventBus.Publish;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventBusPublisher _eventBusPublisher;
    private readonly IEventMapper _eventMapper;
    private readonly IPrioritiesTopicConfiguration _prioritiesTopicConfiguration;

    public IntegrationEventPublisher(IEventBusPublisher eventBusPublisher,
        IEventMapper eventMapper,
        IPrioritiesTopicConfiguration prioritiesTopicConfiguration)
    {
        _eventBusPublisher = eventBusPublisher;
        _eventMapper = eventMapper;
        _prioritiesTopicConfiguration = prioritiesTopicConfiguration;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents)
            .Where(@event => @event is not null)
            .ToList()
            .AsReadOnly();

        await _eventBusPublisher.PublishAsync(_prioritiesTopicConfiguration.TopicName, integrationEvents, cancellationToken);
    }
}
