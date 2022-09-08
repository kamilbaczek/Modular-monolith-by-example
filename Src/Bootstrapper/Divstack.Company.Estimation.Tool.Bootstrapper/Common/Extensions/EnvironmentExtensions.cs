namespace Divstack.Company.Estimation.Tool.Bootstrapper.Common.Extensions;

internal static class EnvironmentExtensions
{
    private const string LocalEnvironmentName = "Local";
    private const string DevEnvironmentName = "Dev";

    internal static bool IsForDevs(this IHostEnvironment hostContext) =>
        hostContext.IsEnvironment(LocalEnvironmentName) || hostContext.IsEnvironment(DevEnvironmentName);
}
