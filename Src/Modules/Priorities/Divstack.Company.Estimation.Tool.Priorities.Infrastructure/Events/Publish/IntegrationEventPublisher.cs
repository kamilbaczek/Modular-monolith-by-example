namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish;

using Inquiries.Application.Common.Interfaces;
using Mapper;
using NServiceBus;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventMapper _eventMapper;
    private readonly IMessageSession _messageSession;

    public IntegrationEventPublisher(IMessageSession messageSession,
        IEventMapper eventMapper)
    {
        _messageSession = messageSession;
        _eventMapper = eventMapper;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents)
            .Where(@event => @event is not null)
            .ToList()
            .AsReadOnly();

        foreach (var integrationEvent in integrationEvents)
            await _messageSession.SendLocal(integrationEvent);
    }
}
