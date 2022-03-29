namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks.Memory;

using Microsoft.Extensions.DependencyInjection;

internal static class MemoryHealthChecksModule
{
    private const string Shared = "Shared";
    private const int MaximumMegabytesAllocated = 512;
    private const string Memory = "Memory";
    internal static IHealthChecksBuilder AddMemoryHealthCheck(this IHealthChecksBuilder services)
    {
        services.AddProcessAllocatedMemoryHealthCheck(MaximumMegabytesAllocated, Memory, null, new[]
        {
            Shared
        });

        return services;
    }
}
