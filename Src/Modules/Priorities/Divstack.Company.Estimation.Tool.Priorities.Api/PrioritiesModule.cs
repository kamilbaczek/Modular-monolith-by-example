[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Priorities.Api;

using Domain.UserAccess;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.FeatureFlags;
using UserAccess;

internal static class PrioritiesModule
{
    public static void AddPrioritiesModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddInfrastructure(configuration);
    }

    public static void UsePrioritiesModule(this IApplicationBuilder app) =>
        app.UseInfrastructure();
}
