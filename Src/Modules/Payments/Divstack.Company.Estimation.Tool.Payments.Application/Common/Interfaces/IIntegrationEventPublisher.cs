namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Interfaces;

using Shared.DDD.BuildingBlocks;

public interface IIntegrationEventPublisher
{
    Task Publish(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}
