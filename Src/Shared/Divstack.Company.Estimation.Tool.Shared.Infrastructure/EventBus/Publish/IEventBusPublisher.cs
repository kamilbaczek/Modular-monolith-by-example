namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish;

using DDD.BuildingBlocks;

public interface IEventBusPublisher
{
    Task PublishAsync(string topic, IReadOnlyCollection<IntegrationEvent> integrationEvents,
        CancellationToken cancellationToken = default);
}
