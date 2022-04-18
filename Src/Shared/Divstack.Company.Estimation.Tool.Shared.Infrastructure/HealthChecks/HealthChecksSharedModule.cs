namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks;

using Azure.Configuration.FeatureFlags;
using BackgroundProcessing.HealthChecks;
using FeatureFlag;
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

        var enabled = IsUIEnabled();
        if (!enabled) return;

        app.UseHealthChecksUI(options =>
        {
            options.UIPath = HealthCheckUi;
            options.ApiPath = HealthCheckApi;
        });

        bool IsUIEnabled()
        {
            var featureFlagsChecker = app.ApplicationServices.GetRequiredService<IFeatureFlagsChecker>();
            var enabled = featureFlagsChecker.IsEnabled(FeatureFlags.HealthChecksIU);

            return enabled;
        }
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
