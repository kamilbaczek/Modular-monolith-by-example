namespace Divstack.Company;

using Estimation.Tool.Shared.DDD.BuildingBlocks;
using NServiceBus;

public record struct ValuationCompleted(
    Guid InquiryId,
    Guid ValuationId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent;
