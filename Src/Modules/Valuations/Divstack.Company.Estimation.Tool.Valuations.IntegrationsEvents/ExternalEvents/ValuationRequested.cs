namespace Divstack.Company;

using Estimation.Tool.Shared.DDD.BuildingBlocks;
using NServiceBus;

public record struct ValuationRequested(
    Guid InquiryId,
    Guid ValuationId) : IntegrationEvent;
