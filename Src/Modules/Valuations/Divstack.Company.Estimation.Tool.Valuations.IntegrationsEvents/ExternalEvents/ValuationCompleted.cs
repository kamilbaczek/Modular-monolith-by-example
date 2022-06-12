namespace Divstack.Company;

using Estimation.Tool.Shared.DDD.BuildingBlocks;

public record struct ValuationCompleted(
    Guid InquiryId,
    Guid ValuationId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent;
