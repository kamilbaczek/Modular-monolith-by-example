namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record struct ProposalCancelled(
    Guid CancelledBy,
    Guid ProposalId,
    Guid ValuationId) : IIntegrationEvent;
