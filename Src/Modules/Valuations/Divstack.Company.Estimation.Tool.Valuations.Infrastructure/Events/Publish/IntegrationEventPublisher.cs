﻿namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Publish;

using Application.Common.Interfaces;
using Mapper;
using Shared.DDD.BuildingBlocks;
using Shared.Infrastructure.EventBus.Publish;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventBusPublisher _eventBusPublisher;
    private readonly IEventMapper _eventMapper;

    public IntegrationEventPublisher(IEventBusPublisher eventBusPublisher,
        IEventMapper eventMapper)
    {
        _eventBusPublisher = eventBusPublisher;
        _eventMapper = eventMapper;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents)
            .Where(@event => @event is not null)
            .ToList()
            .AsReadOnly();

        await _eventBusPublisher.PublishAsync("valuations", integrationEvents, cancellationToken);
    }
}
