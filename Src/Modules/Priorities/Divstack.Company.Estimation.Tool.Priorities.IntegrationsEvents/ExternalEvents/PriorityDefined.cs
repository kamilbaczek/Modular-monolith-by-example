namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record struct PriorityDefined(Guid ValuationId, Guid PriorityId, DateTime DeadlineDate) : IntegrationEvent;
