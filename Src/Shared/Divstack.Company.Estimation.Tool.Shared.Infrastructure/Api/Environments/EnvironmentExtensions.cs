namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Environments;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

internal static class EnvironmentExtensions
{
    private const string LocalEnvironmentName = "Local";
    private const string ProductionEnvironmentName = "Production";

    internal static bool IsLocal(this IWebHostEnvironment env)
    {
        return env.IsEnvironment(LocalEnvironmentName);
    }

    internal static bool IsProduction(this IWebHostEnvironment env)
    {
        return env.IsEnvironment(ProductionEnvironmentName);
    }
}
