namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Commands.Archive;

using Ardalis.GuardClauses;
using Common.Interfaces;
using Domain;
using MediatR;
using Shared.Infrastructure.EventBus.Subscribe;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ArchivePriorityCommandCommandHandler : IIntegrationEventHandler<ProposalSuggested>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IPrioritiesRepository _prioritiesRepository;
    public ArchivePriorityCommandCommandHandler(IPrioritiesRepository prioritiesRepository,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _prioritiesRepository = prioritiesRepository;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async ValueTask Handle(ProposalSuggested @event, CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Create(@event.ValuationId);
        var priority = await _prioritiesRepository.GetAsync(valuationId, cancellationToken);
        if (priority is null)
            throw new NotFoundException(@event.ValuationId.ToString(), nameof(Priority));

        priority.Archive();

        await _prioritiesRepository.CommitAsync(priority, cancellationToken);
        await _integrationEventPublisher.PublishAsync(priority.DomainEvents, cancellationToken);
    }
}
