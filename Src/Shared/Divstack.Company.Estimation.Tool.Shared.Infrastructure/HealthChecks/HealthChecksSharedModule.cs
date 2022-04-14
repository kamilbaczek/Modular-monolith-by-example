namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks;

using System.Net;
using BackgroundProcessing.HealthChecks;
using global::HealthChecks.UI.Client;
using Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksSharedModule
{
    private const string HealthCheck = "/healthcheck";
    private const string HealthCheckUi = "/healthchecks-ui";
    private const string HealthCheckApi = "/api-health";


    internal static IServiceCollection AddSharedHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddMemoryHealthCheck()
            .AddBackgroundProcessingHealthCheck();

        services.AddHealthChecksUI(setup => setup.AddHealthCheckEndpoint("Estimation Tool - Health Checks", $"http://{Dns.GetHostName()}/healthcheck"))
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
            options.UIPath = HealthCheckUi;
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
