using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ProposalRejected(
        Guid ValuationId,
        Guid ProposalId,
        decimal? Value,
        string Currency,
        string Email) : IntegrationEvent;
}
