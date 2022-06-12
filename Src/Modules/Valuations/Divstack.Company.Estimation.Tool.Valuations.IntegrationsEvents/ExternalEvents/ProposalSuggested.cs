namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record struct ProposalSuggested(
    Guid ValuationId,
    Guid ProposalId,
    Guid InquiryId,
    decimal? Value,
    string Currency,
    string Description) : IntegrationEvent;
