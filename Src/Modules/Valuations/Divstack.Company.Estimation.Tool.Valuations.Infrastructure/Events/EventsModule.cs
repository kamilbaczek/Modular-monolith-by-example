namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events;

using Mapper;
using Microsoft.Extensions.DependencyInjection;
using Valuations.Application.Interfaces;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
