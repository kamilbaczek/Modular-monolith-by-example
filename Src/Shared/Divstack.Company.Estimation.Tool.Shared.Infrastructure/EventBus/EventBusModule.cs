namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

using Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class EventBusModule
{
    internal static void AddEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IEventBusConfiguration, EventBusConfiguration>();
    }
}
