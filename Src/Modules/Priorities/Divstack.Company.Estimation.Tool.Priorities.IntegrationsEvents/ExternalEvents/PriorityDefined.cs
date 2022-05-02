namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationsEvents.ExternalEvents;

using System.Text.Json;
using Shared.DDD.BuildingBlocks;

public record PriorityDefined(Guid ValuationId, Guid PriorityId) : IntegrationEvent
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
