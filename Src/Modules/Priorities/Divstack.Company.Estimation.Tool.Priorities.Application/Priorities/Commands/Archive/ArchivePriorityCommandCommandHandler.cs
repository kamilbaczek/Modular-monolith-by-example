// namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Commands.Archive;
//
// using Ardalis.GuardClauses;
// using Common.Interfaces;
// using Domain;
// using Shared.Infrastructure.EventBus.Publish;
// using Shared.Infrastructure.EventBus.Subscribe;
// using Valuations.IntegrationsEvents.ExternalEvents;
//
// internal sealed class ArchivePriorityCommandCommandHandler : IIntegrationEventHandler<ProposalSuggested>
// {
//     private readonly IEventBusPublisher _integrationEventPublisher;
//     private readonly IPrioritiesRepository _prioritiesRepository;
//     public ArchivePriorityCommandCommandHandler(IPrioritiesRepository prioritiesRepository,
//         IEventBusPublisher integrationEventPublisher)
//     {
//         _prioritiesRepository = prioritiesRepository;
//         _integrationEventPublisher = integrationEventPublisher;
//     }
//
//     public async ValueTask Handle(ProposalSuggested proposalApprovedEvent, CancellationToken cancellationToken)
//     {
//         // var valuationId = ValuationId.Create(proposalApprovedEvent.ValuationId);
//         // var priority = await _prioritiesRepository.GetAsync(valuationId, cancellationToken);
//         // if (priority is null)
//         //     throw new NotFoundException(proposalApprovedEvent.ValuationId.ToString(), nameof(Priority));
//         //
//         // priority.Archive();
//         //
//         // await _prioritiesRepository.CommitAsync(priority, cancellationToken);
//         // await _integrationEventPublisher.PublishAsync(priority.DomainEvents, cancellationToken);
//     }
// }


