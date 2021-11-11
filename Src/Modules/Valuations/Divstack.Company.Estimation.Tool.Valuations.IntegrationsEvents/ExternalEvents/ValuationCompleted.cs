using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

public record ValuationCompleted(
    Guid InquiryId,
    Guid ValuationId,
    decimal? Value,
    string Currency) : IntegrationEvent;
