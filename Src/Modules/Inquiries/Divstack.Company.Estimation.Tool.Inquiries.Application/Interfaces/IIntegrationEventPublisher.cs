using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces
{
    public interface IIntegrationEventPublisher
    {
        void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
    }
}
