namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events;

using Application.Common.IntegrationsEvents;
using Mapper;
using MediatR;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IMediator _mediator;
    private readonly IEventMapper _eventMapper;

    public IntegrationEventPublisher(IEventMapper eventMapper,
        IMediator mediator)
    {
        _mediator = mediator;
        _eventMapper = eventMapper;
    }
    
    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents);
        foreach (var integrationEvent in integrationEvents)
        {
            await _mediator.Publish(integrationEvent, cancellationToken);
        }
    }
}
