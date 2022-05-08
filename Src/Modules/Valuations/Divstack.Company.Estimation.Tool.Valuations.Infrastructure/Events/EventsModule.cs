namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events;

using Application.Common.Interfaces;
using Mapper;
using Microsoft.Extensions.DependencyInjection;
using Publish;
using Publish.Mapper;
using Subscribe;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();

        services.AddSubscribers();
    }
}
