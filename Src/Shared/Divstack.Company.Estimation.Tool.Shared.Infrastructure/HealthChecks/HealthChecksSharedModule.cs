namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks;

using BackgroundProcessing.HealthChecks;
using Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksSharedModule
{
    private const string HealthCheck = "/healthcheck";
    private const string HealthCheckApi = "/api-health";

    internal static IServiceCollection AddSharedHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddMemoryHealthCheck()
            .AddBackgroundProcessingHealthCheck();

        return services;
    }

    internal static void UseSharedHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks(HealthCheck);
    }

    public static IEndpointRouteBuilder MapSharedHealthChecks(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks(HealthCheckApi);

        return endpoints;
    }
}
