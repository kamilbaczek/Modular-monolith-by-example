namespace Divstack.Company;

using Estimation.Tool.Shared.DDD.BuildingBlocks;

public record struct ProposalRejected(
    Guid ValuationId,
    Guid ProposalId,
    decimal? Value,
    string Currency) : IntegrationEvent;
