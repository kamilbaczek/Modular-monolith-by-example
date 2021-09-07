using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ProposalSuggested(
        string FullName,
        Guid ValuationId,
        Guid ProposalId,
        decimal? Value,
        string Currency,
        string Description) : IntegrationEvent;
}
