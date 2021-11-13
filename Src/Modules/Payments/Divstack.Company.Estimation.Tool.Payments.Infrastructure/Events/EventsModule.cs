namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events;

using Application.Common.Interfaces;
using Mapper;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
