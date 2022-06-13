namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Publish.Mapper;

using Shared.DDD.BuildingBlocks;

internal interface IEventMapper
{
    List<IntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events);
}
