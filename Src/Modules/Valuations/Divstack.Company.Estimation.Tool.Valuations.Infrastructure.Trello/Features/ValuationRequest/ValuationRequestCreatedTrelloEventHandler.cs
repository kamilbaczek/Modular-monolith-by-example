namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Features.ValuationRequest;

using Core;
using Core.Constants;
using IntegrationsEvents.ExternalEvents;
using Shared.Infrastructure.EventBus;
using Shared.Infrastructure.EventBus.Subscribe;

internal sealed class ValuationRequestCreatedTrelloEventHandler : IIntegrationEventHandler<ValuationRequested>
{
    private readonly ITrelloTaskCreator _trelloTaskCreator;

    public ValuationRequestCreatedTrelloEventHandler(ITrelloTaskCreator trelloTaskCreator)
    {
        _trelloTaskCreator = trelloTaskCreator;
    }

    public async ValueTask Handle(ValuationRequested @event, CancellationToken cancellationToken)
    {
        var taskName = GenerateTaskName(@event.ValuationId);
        var description = GenerateDescription(@event, new List<string>());
        await _trelloTaskCreator.CreateAsync(ListNames.Todo, taskName, description, cancellationToken);
    }

    private static string GenerateDescription(ValuationRequested notification,
        IEnumerable<string> servicesNames)
    {
        return $"Valuation: {notification.ValuationId} " +
               $"{Environment.NewLine}" +
               $"Requested: {string.Join($"{Environment.NewLine}", servicesNames)}";
    }

    private static string GenerateTaskName(Guid id)
    {
        return $"#{id} [Valuation]";
    }
}
