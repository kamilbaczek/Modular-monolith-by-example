namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks;

using global::HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksSharedModule
{
    private const string HealthCheck = "/healthcheck";
    private const string HealthCheckUI = "/healthchecks-ui";
    private const string HealthCheckApi = "/api-health";
    private const int MaximumMegabytesAllocated = 512;
    private const string Shared = "Shared";

    internal static IServiceCollection AddSharedHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddProcessAllocatedMemoryHealthCheck(MaximumMegabytesAllocated, "Memory", null, new[] { Shared })
            .AddHangfire(hangfire =>
            {
                hangfire.MaximumJobsFailed = 5;
                hangfire.MinimumAvailableServers = 1;
            }, "Background Processing", null, new[] { Shared });

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
        app.UseHealthChecks(HealthCheck, options);
        app.UseHealthChecksUI(options =>
        {
            options.UIPath = HealthCheckUI;
            options.ApiPath = HealthCheckApi;
        });
    }

    public static IEndpointRouteBuilder MapSharedHealthChecks(
        this IEndpointRouteBuilder endpoints)
    {
        var options = new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        };
        endpoints.MapHealthChecksUI();
        endpoints.MapHealthChecks(HealthCheckApi, options);

        return endpoints;
    }
}
