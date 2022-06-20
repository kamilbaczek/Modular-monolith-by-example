namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using Shared.DDD.BuildingBlocks;

public record struct ValuationCompleted(
    Guid InquiryId,
    Guid ValuationId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent;
