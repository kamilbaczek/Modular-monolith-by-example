using System.Collections.Generic;
using System.Threading;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces
{
    public interface IIntegrationEventPublisher
    {
        void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
    }
}