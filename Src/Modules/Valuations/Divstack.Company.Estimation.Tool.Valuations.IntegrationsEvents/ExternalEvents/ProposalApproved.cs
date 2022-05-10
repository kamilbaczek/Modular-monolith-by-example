namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System.Text.Json;
using Shared.DDD.BuildingBlocks;

public record ProposalApproved(
    Guid ValuationId,
    Guid ProposalId,
    Guid SuggestedBy,
    string Currency,
    decimal? Value) : IntegrationEvent
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
