namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Interfaces;

using Shared.DDD.BuildingBlocks;

public interface IIntegrationEventPublisher
{
    void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
}
