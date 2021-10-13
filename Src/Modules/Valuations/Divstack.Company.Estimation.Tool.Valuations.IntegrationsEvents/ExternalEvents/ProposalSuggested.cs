using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents
{
    public record ProposalSuggested(
        Guid ValuationId,
        Guid ProposalId,
        Guid InquiryId,
        decimal? Value,
        string Currency,
        string Description) : IntegrationEvent;
}