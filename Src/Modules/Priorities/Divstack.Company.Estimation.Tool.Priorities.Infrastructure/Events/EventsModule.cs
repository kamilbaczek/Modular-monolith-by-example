namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events;

using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Publish;
using Publish.Configuration;
using Publish.Mapper;
using Subscribe;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
        services.AddScoped<IPrioritiesTopicConfiguration, PrioritiesTopicConfiguration>();

        services.AddSubscribers();
    }
}
