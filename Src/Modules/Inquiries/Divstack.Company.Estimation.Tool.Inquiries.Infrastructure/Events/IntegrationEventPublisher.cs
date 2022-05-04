namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;

using Publish.Mapper;
using Shared.DDD.BuildingBlocks;
using Shared.Infrastructure.EventBus.Publish;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventMapper _eventMapper;
    private readonly IEventBusPublisher _eventBusPublisher;

    public IntegrationEventPublisher(IEventBusPublisher eventBusPublisher,
        IEventMapper eventMapper)
    {
        _eventBusPublisher = eventBusPublisher;
        _eventMapper = eventMapper;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents).Where(@event => @event is not null).ToList().AsReadOnly();
        await _eventBusPublisher.PublishAsync("inquiries", integrationEvents, cancellationToken);
    }
}
