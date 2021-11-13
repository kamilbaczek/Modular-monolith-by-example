namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Environments;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

internal static class EnvironmentExtensions
{
    private static readonly string LocalEnvironmentName = "Local";

    internal static bool IsLocal(this IWebHostEnvironment env)
    {
        return env.IsEnvironment(LocalEnvironmentName);
    }
}
