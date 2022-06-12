namespace Divstack.Company;

using Estimation.Tool.Shared.DDD.BuildingBlocks;
using NServiceBus;

public record struct ProposalCancelled(
    Guid CancelledBy,
    Guid ProposalId,
    Guid ValuationId) : IntegrationEvent, IMessage;
