using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces
{
    public interface IEventPublisher
    {
        void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
    }
}
