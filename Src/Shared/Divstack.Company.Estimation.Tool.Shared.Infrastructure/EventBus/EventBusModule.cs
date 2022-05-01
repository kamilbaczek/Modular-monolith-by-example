namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

using Configuration;
using Publish;

internal static class EventBusModule
{
    internal static void AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBusPublisher, EventBusPublisher>();
        services.AddSingleton<IEventBusConfiguration, EventBusConfiguration>();
    }
}
