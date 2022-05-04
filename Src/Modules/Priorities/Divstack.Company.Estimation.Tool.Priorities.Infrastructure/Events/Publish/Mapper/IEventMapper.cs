namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish.Mapper;

using Shared.DDD.BuildingBlocks;

public interface IEventMapper
{
    List<IntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events);
}
