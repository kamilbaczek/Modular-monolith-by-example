namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record ValuationRequested(
    Guid InquiryId,
    Guid ValuationId) : IntegrationEvent;
