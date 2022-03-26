namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Controllers;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    internal static IServiceCollection AddInternalControllers(this IServiceCollection services)
    {
        services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new InternalControllersFeatureProvider());
            });

        return services;
    }

}
