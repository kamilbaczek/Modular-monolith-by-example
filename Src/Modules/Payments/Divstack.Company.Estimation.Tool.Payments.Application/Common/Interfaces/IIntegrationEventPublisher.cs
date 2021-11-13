namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Interfaces;

using Shared.DDD.BuildingBlocks;

public interface IIntegrationEventPublisher
{
    void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
}
