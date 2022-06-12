namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events;

using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Publish;
using Publish.Mapper;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IEventMapper, EventMapper>();
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
    }
}
