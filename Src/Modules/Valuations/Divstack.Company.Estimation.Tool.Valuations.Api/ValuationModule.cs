[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Valuations.Api;

using Domain.UserAccess;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAccess;

internal static class ValuationModule
{
    public static IServiceCollection AddValuationsModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddInfrastructure(configuration);

        return services;
    }

    public static void UseValuationModule(this IApplicationBuilder app) => app.UseInfrastructure();
}
