namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    internal static IServiceCollection AddHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks();

        return services;
    }

    internal static void UseHealthChecks(this IApplicationBuilder app)
    {
    }
}
