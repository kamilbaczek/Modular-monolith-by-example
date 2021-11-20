namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events;

using Application.Common.IntegrationsEvents;
using Mapper;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddTransient<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
