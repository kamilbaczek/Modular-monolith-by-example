using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Mapper;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
