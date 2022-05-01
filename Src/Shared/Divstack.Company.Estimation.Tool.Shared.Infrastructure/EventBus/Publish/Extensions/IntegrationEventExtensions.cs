namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish.Extensions;

using System.Text.Json;
using DDD.BuildingBlocks;

internal static class IntegrationEventExtensions
{
    internal static string ToJsonString(this IntegrationEvent @event)
    {
        return JsonSerializer.Serialize(@event);
    }

    internal static string GetTypeName(this IntegrationEvent @event)
    {
        return @event.GetType().Name;
    }
}
