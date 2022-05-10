namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System.Text.Json;
using Shared.DDD.BuildingBlocks;

public record ProposalCancelled(
    Guid CancelledBy,
    Guid ProposalId,
    Guid ValuationId) : IntegrationEvent
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
