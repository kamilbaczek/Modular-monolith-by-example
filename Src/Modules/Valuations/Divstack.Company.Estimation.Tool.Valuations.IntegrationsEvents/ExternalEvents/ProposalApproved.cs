using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ProposalApproved(
        Guid ValuationId,
        Guid ProposalId,
        Guid SuggestedBy,
        string Currency,
        decimal? Value) : IntegrationEvent;
}