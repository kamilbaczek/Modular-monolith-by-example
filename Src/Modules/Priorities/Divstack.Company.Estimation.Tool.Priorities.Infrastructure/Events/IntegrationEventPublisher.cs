namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events;

using Common.Interfaces;
using Mapper;
using MediatR;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventMapper _eventMapper;
    private readonly IMediator _mediator;

    public IntegrationEventPublisher(IMediator mediator,
        IEventMapper eventMapper)
    {
        _mediator = mediator;
        _eventMapper = eventMapper;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents).Where(@event => @event is not null);
        foreach (var integrationEvent in integrationEvents)
        {
            await _mediator.Publish(integrationEvent, cancellationToken);
        }
    }
}
