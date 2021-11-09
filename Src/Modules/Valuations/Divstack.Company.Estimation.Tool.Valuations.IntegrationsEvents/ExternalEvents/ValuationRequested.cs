using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ValuationRequested(
        Guid InquiryId,
        Guid ValuationId,
        DateTime Deadline) : IntegrationEvent;
}