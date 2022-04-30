namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDD.BuildingBlocks;

public interface IEventBusPublisher
{
    Task PublishAsync(string topic, IReadOnlyCollection<IntegrationEvent> integrationEvents,
        CancellationToken cancellationToken = default);
}
