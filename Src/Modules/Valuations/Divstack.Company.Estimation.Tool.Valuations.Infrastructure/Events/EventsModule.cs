using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events.Mapper;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
