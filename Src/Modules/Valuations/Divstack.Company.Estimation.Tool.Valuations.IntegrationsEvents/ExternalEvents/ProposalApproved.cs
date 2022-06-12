namespace Divstack.Company.Messages;

using Estimation.Tool.Shared.DDD.BuildingBlocks;
using NServiceBus;

public record struct ProposalApproved(
    Guid ValuationId,
    Guid ProposalId,
    Guid SuggestedBy,
    string Currency,
    decimal? Value) : IntegrationEvent;
