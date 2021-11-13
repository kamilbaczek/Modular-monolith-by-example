namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System;
using Shared.DDD.BuildingBlocks;

public record ProposalSuggested(
    Guid ValuationId,
    Guid ProposalId,
    Guid InquiryId,
    decimal? Value,
    string Currency,
    string Description) : IntegrationEvent;
