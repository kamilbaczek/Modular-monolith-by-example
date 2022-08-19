namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish.Mapper;

using Shared.DDD.BuildingBlocks;

public interface IEventMapper
{
    List<IIntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events);
}
