namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;

using Publish.Configuration;
using Publish.Mapper;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddSingleton<IInquiriesTopicConfiguration, InquiriesTopicConfiguration>();
        services.AddScoped<IIntegrationEventPublisher, IntegrationEventPublisher>();
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
