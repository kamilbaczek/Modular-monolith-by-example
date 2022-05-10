[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Priorities.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Priorities;

using Shared.Infrastructure.EventBus.Subscribe.Extensions;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddIntegrationEventsHandlers(typeof(ApplicationModule));

        return services;
    }
}
