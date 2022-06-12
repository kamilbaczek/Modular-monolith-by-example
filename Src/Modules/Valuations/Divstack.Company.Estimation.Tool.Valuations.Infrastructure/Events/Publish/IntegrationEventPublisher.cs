namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Publish;

using Application.Common.Interfaces;
using IntegrationsEvents.ExternalEvents;
using Mapper;
using Messages;
using NServiceBus;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IMessageSession _bus;
    private readonly IEventMapper _eventMapper;

    public IntegrationEventPublisher(IMessageSession bus,
        IEventMapper eventMapper)
    {
        _bus = bus;
        _eventMapper = eventMapper;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper
            .Map(domainEvents)
            .ToList()
            .AsReadOnly();

        foreach (var @event in integrationEvents)
        {
            switch (@event)
            {
                case ValuationRequested valuationRequested:
                    await _bus.SendLocal(valuationRequested);
                    break;
                case ProposalSuggested proposalSuggested:
                    await _bus.SendLocal(proposalSuggested);
                    break;
                case ProposalApproved proposalApproved:
                    await _bus.SendLocal(proposalApproved);
                    break;
                case ValuationCompleted valuationCompleted:
                    await _bus.SendLocal(valuationCompleted);
                    break;
            }
        }
    }
}
