namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events;

using Application.Common.IntegrationsEvents;
using Publish;
using Publish.Configuration;
using Publish.Mapper;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddTransient<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
        services.AddSingleton<IPaymentsTopicConfiguration, PaymentsTopicConfiguration>();
    }
}
