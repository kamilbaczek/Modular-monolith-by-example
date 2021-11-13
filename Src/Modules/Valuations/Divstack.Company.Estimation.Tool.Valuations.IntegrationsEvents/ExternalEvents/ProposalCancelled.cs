namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System;
using Shared.DDD.BuildingBlocks;

public record ProposalCancelled(
    Guid CancelledBy,
    Guid ProposalId,
    Guid ValuationId) : IntegrationEvent;
