namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Mapper;

using Shared.DDD.BuildingBlocks;

internal interface IEventMapper
{
    IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events);
}
