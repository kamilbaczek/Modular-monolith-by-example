namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Mapper;

using Shared.DDD.BuildingBlocks;

public interface IEventMapper
{
    IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events);
}
