namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;
using Microsoft.AspNetCore.Builder;
using Middleware;

internal static class Extensions
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        services.AzureApplicationInsights();

        return services;
    }

    internal static IApplicationBuilder UseObservability(this IApplicationBuilder builder)
    {
        return builder.UseTelemetry();
    }
}
