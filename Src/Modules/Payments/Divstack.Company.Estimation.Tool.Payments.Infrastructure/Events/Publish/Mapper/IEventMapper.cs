namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish.Mapper;

using Shared.DDD.BuildingBlocks;

public interface IEventMapper
{
    List<IIntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events);
}
