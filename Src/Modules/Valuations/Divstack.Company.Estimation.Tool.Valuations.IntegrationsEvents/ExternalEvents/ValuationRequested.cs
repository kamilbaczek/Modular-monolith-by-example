namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System;
using Shared.DDD.BuildingBlocks;

public record ValuationRequested(
    Guid InquiryId,
    Guid ValuationId,
    DateTime Deadline) : IntegrationEvent;
