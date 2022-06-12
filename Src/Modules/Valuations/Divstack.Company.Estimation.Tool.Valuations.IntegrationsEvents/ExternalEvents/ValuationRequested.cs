namespace Divstack.Company;

using Estimation.Tool.Shared.DDD.BuildingBlocks;

public record struct ValuationRequested(
    Guid InquiryId,
    Guid ValuationId) : IntegrationEvent;
