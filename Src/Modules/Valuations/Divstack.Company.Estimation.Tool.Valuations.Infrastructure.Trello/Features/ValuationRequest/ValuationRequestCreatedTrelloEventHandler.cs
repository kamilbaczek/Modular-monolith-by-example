using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Core;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Core.Constants;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Features.ValuationRequest
{
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
            var services = await _servicesService.GetBatchAsync(notification.ServiceIds, 50, cancellationToken);
            var servicesNames = services.Select(service => service.Name);
            var taskName = GenerateTaskName(notification.ValuationId);
            var description = GenerateDescription(notification, servicesNames);
            await _trelloTaskCreator.CreateAsync(ListNames.Todo, taskName, description, cancellationToken);
        }

        private static string GenerateDescription(ValuationRequested notification,
            IEnumerable<string> servicesNames)
        {
            return $"Client: {notification.ClientEmail} " +
                   $"{Environment.NewLine}" +
                   $"Requested: {string.Join($"{Environment.NewLine}", servicesNames)}";
        }

        private static string GenerateTaskName(Guid id)
        {
            return $"#{id} [Valuation]";
        }
    }
}
