namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record ProposalApproved(
    Guid ValuationId,
    Guid ProposalId,
    Guid SuggestedBy,
    string Currency,
    decimal? Value) : IntegrationEvent;
