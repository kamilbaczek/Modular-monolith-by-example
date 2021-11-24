namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Features.ValuationRequest;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Constants;
using IntegrationsEvents.ExternalEvents;
using MediatR;
using Services.Core.Services.Services;

internal sealed class ValuationRequestCreatedTrelloEventHandler : INotificationHandler<ValuationRequested>
{
    private readonly IServicesService _servicesService;
    private readonly ITrelloTaskCreator _trelloTaskCreator;

    public ValuationRequestCreatedTrelloEventHandler(ITrelloTaskCreator trelloTaskCreator,
        IServicesService servicesService)
    {
        _trelloTaskCreator = trelloTaskCreator;
        _servicesService = servicesService;
    }

    public async Task Handle(ValuationRequested notification, CancellationToken cancellationToken)
    {
        // var services = await _servicesService.GetBatchAsync(notification.ServiceIds, 50, cancellationToken);
        // var servicesNames = services.Select(service => service.Name);
        var taskName = GenerateTaskName(notification.ValuationId);
        var description = GenerateDescription(notification, new List<string>());
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
