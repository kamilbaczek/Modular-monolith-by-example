[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Payments.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Payments.Application;

using Shared.Infrastructure.EventBus.Subscribe.Extensions;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddIntegrationEventsHandlers(typeof(ApplicationModule));

        return services;
    }
}
