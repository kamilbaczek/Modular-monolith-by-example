namespace Divstack.Company.Estimation.Tool.Priorities.Common.Interfaces;

using Shared.DDD.BuildingBlocks;

public interface IIntegrationEventPublisher
{
    Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}
