namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish.Extensions;

using DDD.BuildingBlocks;

internal static class IntegrationEventExtensions
{
    internal static string GetTypeName(this IntegrationEvent @event)
    {
        return @event.GetType().Name;
    }
}
