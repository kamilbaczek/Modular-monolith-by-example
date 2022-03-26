namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks;

using global::HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    private const string HealthUrl = "/health";
    private const string HealthCheckUrl = "/healthcheck";

    private const int MaximumMegabytesAllocated = 512;

    internal static IServiceCollection AddSharedHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddProcessAllocatedMemoryHealthCheck(MaximumMegabytesAllocated);
        services.AddHealthChecksUI()
            .AddInMemoryStorage();

        return services;
    }


    internal static void UseSharedHealthChecks(this IApplicationBuilder app)
    {
        var options = new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        };
        app.UseHealthChecks(HealthUrl, options);
        app.UseHealthChecksUI(config => config.UIPath = HealthCheckUrl);
    }

    public static IEndpointConventionBuilder MapSharedHealthChecks(
        this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapHealthChecks(HealthUrl);
    }
}
