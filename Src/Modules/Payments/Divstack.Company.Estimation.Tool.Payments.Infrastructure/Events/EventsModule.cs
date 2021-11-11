using Divstack.Company.Estimation.Tool.Payments.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
