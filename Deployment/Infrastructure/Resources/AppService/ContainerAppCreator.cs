namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;

using AzureNative.App;
using AzureNative.App.Inputs;
using AzureNative.ContainerRegistry;
using AzureNative.OperationalInsights;
using AzureNative.OperationalInsights.Inputs;
using Pulumi;
using Pulumi.AzureNative.Resources;
using SkuArgs = AzureNative.ContainerRegistry.Inputs.SkuArgs;

internal static class ContainerAppCreator
{
    internal static Registry Create(string environment, ResourceGroup resourceGroup)
    {
        var workspace = new Workspace($"{environment}-loganalytics", new WorkspaceArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Sku = new WorkspaceSkuArgs { Name = "PerGB2018" },
            RetentionInDays = 30,
        });

        var workspaceSharedKeys = Output.Tuple(resourceGroup.Name, workspace.Name).Apply(items =>
            GetSharedKeys.InvokeAsync(new GetSharedKeysArgs
            {
                ResourceGroupName = items.Item1,
                WorkspaceName = items.Item2,
            }));

        var managedEnv = new ManagedEnvironment($"{environment}-env", new ManagedEnvironmentArgs
        {
            ResourceGroupName = resourceGroup.Name,
            AppLogsConfiguration = new AppLogsConfigurationArgs
            {
                Destination = "log-analytics",
                LogAnalyticsConfiguration = new LogAnalyticsConfigurationArgs
                {
                    CustomerId = workspace.CustomerId,
                    SharedKey = workspaceSharedKeys.Apply(r => r.PrimarySharedKey)
                }
            }
        });

        var registry = new Registry($"registry{environment}", new RegistryArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Sku = new SkuArgs { Name = "Basic" },
            AdminUserEnabled = true
        });

        return registry;
    }
}
