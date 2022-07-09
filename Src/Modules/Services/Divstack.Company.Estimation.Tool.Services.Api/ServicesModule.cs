using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Services.Api;

using Core.UserAccess;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.FeatureFlags;
using UserAccess;

public static class ServicesModule
{
    public static void AddServicesModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddDataAccess(configuration);
        services.AddScoped<ICurrentUserService, CurrentUserService>();
    }
}
