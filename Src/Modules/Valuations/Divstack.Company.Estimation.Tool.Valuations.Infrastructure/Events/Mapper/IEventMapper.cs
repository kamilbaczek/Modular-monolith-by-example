namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events.Mapper;

using System.Collections.Generic;
using Shared.DDD.BuildingBlocks;

public interface IEventMapper
{
    IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events);
}
