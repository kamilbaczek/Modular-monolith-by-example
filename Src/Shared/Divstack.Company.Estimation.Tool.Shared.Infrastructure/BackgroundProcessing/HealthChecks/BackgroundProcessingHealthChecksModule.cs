namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class BackgroundProcessingHealthChecksModule
{
    private const string Shared = "Shared";
    private const string BackgroundProcessing = "Background Processing";

    internal static IHealthChecksBuilder AddBackgroundProcessingHealthCheck(this IHealthChecksBuilder services)
    {
        services.AddHangfire(hangfire =>
            {
                hangfire.MaximumJobsFailed = 5;
                hangfire.MinimumAvailableServers = 1;
            }, BackgroundProcessing, null, new[] { Shared });

        return services;
    }
}
