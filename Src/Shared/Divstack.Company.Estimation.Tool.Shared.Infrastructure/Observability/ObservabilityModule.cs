namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;
using Hangfire;
using Microsoft.AspNetCore.Builder;

internal static class ObservabilityModule
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        services.AzureApplicationInsights();

        return services;
    }
}
