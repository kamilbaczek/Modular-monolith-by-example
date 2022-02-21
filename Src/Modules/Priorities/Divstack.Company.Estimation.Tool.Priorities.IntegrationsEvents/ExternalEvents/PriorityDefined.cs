namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationsEvents;

using Shared.DDD.BuildingBlocks;

public record PriorityDefined(Guid ValuationId, Guid PriorityId) : IntegrationEvent;
