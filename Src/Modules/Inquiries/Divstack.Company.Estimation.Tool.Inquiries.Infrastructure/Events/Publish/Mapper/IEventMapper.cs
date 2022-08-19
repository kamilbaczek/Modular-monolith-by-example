namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Publish.Mapper;

using Shared.DDD.BuildingBlocks;

internal interface IEventMapper
{
    List<IIntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events);
}
