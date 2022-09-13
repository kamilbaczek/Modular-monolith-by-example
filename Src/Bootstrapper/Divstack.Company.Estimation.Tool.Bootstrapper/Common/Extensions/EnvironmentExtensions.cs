namespace Divstack.Company.Estimation.Tool.Bootstrapper.Common.Extensions;

internal static class EnvironmentExtensions
{
    private const string LocalEnvironmentName = "Local";
    private const string DevEnvironmentName = "Dev";
    private const string StageEnvironmentName = "Stage";

    internal static bool IsForDevs(this IHostEnvironment hostContext) =>
        hostContext.IsEnvironment(LocalEnvironmentName) || hostContext.IsEnvironment(DevEnvironmentName) || hostContext.IsEnvironment(StageEnvironmentName);
}
