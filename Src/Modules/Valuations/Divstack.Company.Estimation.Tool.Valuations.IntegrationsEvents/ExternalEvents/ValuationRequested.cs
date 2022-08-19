namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record struct ValuationRequested(
    Guid InquiryId,
    Guid ValuationId) : IIntegrationEvent;
