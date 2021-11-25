namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record ProposalRejected(
    Guid ValuationId,
    Guid ProposalId,
    decimal? Value,
    string Currency) : IntegrationEvent;
