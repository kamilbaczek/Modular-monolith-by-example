namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;

using Mapper;
using MediatR;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventMapper _eventMapper;
    private readonly IMediator _mediator;

    public IntegrationEventPublisher(
        IEventMapper eventMapper,
        IMediator mediator)
    {
        _eventMapper = eventMapper;
        _mediator = mediator;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents);
        foreach (var integrationEvent in integrationEvents)
        {
            await _mediator.Publish(integrationEvent, cancellationToken);
        }
    }
}
