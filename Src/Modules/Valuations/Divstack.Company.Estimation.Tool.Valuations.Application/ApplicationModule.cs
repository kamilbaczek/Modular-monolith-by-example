[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Valuations.Application;

using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.EventBus;
using Shared.Infrastructure.EventBus.Subscribe;
using Shared.Infrastructure.EventBus.Subscribe.Extensions;
using Valuations.Commands.SuggestProposal;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddIntegrationEventsHandlers(typeof(ApplicationModule));

        return services;
    }
}
