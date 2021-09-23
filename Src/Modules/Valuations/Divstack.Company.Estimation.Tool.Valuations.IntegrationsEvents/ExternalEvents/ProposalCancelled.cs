using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ProposalCancelled(
        Guid CancelledBy,
        Guid ProposalId,
        Guid ValuationId) : IntegrationEvent;
}