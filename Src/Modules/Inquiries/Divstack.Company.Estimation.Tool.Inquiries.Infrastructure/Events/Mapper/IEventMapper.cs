using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Mapper;

public interface IEventMapper
{
    IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events);
}
