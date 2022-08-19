namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Publish.Mapper;

using Shared.DDD.BuildingBlocks;

public interface IEventMapper
{
    IReadOnlyCollection<IIntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events);
}
