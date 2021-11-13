namespace Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;

using System.Collections.Generic;
using Shared.DDD.BuildingBlocks;

public interface IIntegrationEventPublisher
{
    void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
}
