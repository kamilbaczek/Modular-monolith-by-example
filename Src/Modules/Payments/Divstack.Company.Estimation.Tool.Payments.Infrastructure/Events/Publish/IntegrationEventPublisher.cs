namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish;

using Application.Common.IntegrationsEvents;
using Configuration;
using Mapper;
using Shared.DDD.BuildingBlocks;
using Shared.Infrastructure.EventBus.Publish;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventBusPublisher _eventBusPublisher;
    private readonly IEventMapper _eventMapper;
    private readonly IPaymentsTopicConfiguration _paymentsTopicConfiguration;

    public IntegrationEventPublisher(IEventBusPublisher eventBusPublisher,
        IEventMapper eventMapper,
        IPaymentsTopicConfiguration paymentsTopicConfiguration)
    {
        _eventBusPublisher = eventBusPublisher;
        _eventMapper = eventMapper;
        _paymentsTopicConfiguration = paymentsTopicConfiguration;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents).Where(@event => @event is not null).ToList().AsReadOnly();
        await _eventBusPublisher.PublishAsync(_paymentsTopicConfiguration.TopicName, integrationEvents, cancellationToken);
    }
}
