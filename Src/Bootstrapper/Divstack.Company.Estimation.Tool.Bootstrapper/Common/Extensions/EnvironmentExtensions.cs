namespace Divstack.Company.Estimation.Tool.Bootstrapper.Extensions;

using Microsoft.Extensions.Hosting;

internal static class EnvironmentExtensions
{
    private const string LocalEnvironmentName = "Local";

    internal static bool IsForDevs(this IHostEnvironment hostContext)
    {
        return hostContext.IsEnvironment(LocalEnvironmentName) || hostContext.IsDevelopment();
    }
}
