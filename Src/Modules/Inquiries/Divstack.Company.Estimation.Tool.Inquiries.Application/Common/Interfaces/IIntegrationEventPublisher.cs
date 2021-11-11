using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Interfaces;

public interface IIntegrationEventPublisher
{
    void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
}
