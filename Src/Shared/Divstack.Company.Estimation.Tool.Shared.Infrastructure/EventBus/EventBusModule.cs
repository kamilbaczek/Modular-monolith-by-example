namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

using Configuration;
using Publish;
using Subscribe;
using Subscribe.Logger;

internal static class EventBusModule
{
    internal static void AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBusPublisher, EventBusPublisher>();
        services.AddScoped<ISubscriberLogger, SubscriberLogger>();
        services.AddSingleton<IEventBusConfiguration, EventBusConfiguration>();
    }
}
