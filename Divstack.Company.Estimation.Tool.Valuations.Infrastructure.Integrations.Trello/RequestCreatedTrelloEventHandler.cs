using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Core;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Core.Constants;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello
{
    internal sealed class RequestCreatedTrelloEventHandler : INotificationHandler<ValuationRequestedEvent>
    {
        private readonly IServicesService _servicesService;
        private readonly ITrelloTaskCreator _trelloTaskCreator;

        public RequestCreatedTrelloEventHandler(ITrelloTaskCreator trelloTaskCreator, IServicesService servicesService)
        {
            _trelloTaskCreator = trelloTaskCreator;
            _servicesService = servicesService;
        }

        public async Task Handle(ValuationRequestedEvent notification, CancellationToken cancellationToken)
        {
            var servicesIdsAsGuids = notification.ServiceIds.Select(serviceId => serviceId.Value).ToList();
            var services = await _servicesService.GetBatchAsync(servicesIdsAsGuids, 50, cancellationToken);
            var servicesNames = services.Select(service => service.Name);
            var taskName = GenerateTaskName(notification.ValuationId.Value);
            var description = GenerateDescription(notification, servicesNames);
            await _trelloTaskCreator.CreateAsync(ListNames.Todo, taskName, description, cancellationToken);
        }

        private static string GenerateDescription(ValuationRequestedEvent notification, IEnumerable<string> servicesNames)
        {
            return $"Client: {notification.ClientEmail.Value} " +
                   $"{Environment.NewLine}" +
                   $"Requested: {string.Join($"{Environment.NewLine}", servicesNames)}";
        }

        private static string GenerateTaskName(Guid id)
        {
            return $"#{id} [Valuation]";
        }
    }
}
