namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record struct ProposalApproved(
    Guid ValuationId,
    Guid ProposalId,
    Guid SuggestedBy,
    string Currency,
    decimal? Value) : IIntegrationEvent;
