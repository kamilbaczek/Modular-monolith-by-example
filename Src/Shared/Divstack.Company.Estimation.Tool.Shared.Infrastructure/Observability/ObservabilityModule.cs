namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;
using Infrastructure.FeatureFlags;
using Microsoft.Extensions.Logging;

internal static class ObservabilityModule
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.ObservabilityModule);
        if (!moduleEnabled) return services;

        services.AzureApplicationInsights();

        return services;
    }
}
