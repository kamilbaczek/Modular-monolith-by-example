[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Valuations.Application;

using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.EventBus;
using Shared.Infrastructure.EventBus.Subscribe;
using Valuations.Commands.SuggestProposal;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssembliesOf(typeof(ApplicationModule))
                .AddClasses(classes => classes.AssignableTo(typeof(IIntegrationEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
}
