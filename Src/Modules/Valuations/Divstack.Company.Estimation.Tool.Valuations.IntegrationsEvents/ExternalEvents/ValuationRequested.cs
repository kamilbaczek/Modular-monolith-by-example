using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ValuationRequested(
        Guid ValuationId,
        IReadOnlyList<Guid> ServiceIds,
        string ClientEmail) : IntegrationEvent;
}
