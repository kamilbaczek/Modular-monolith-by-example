namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events;

using Microsoft.Extensions.DependencyInjection;
using Publish.Mapper;

internal static class EventsModule
{
    internal static void AddEvents(this IServiceCollection services)
    {
        services.AddScoped<IEventMapper, EventMapper>();
    }
}
