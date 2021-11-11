using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Payments.Application.Common.Interfaces;

public interface IIntegrationEventPublisher
{
    void Publish(IReadOnlyCollection<IDomainEvent> domainEvents);
}
