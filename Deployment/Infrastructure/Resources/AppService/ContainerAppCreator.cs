namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;

using AzureNative.App;
using AzureNative.App.Inputs;
using AzureNative.ContainerRegistry;
using AzureNative.OperationalInsights;
using AzureNative.OperationalInsights.Inputs;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.Docker;
using ContainerArgs = AzureNative.App.Inputs.ContainerArgs;
using SecretArgs = AzureNative.App.Inputs.SecretArgs;
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

        var credentials = Output.Tuple(resourceGroup.Name, registry.Name).Apply(items =>
           ListRegistryCredentials.InvokeAsync(new ListRegistryCredentialsArgs
           {
               ResourceGroupName = items.Item1,
               RegistryName = items.Item2
           }));
        var adminUsername = credentials.Apply(credentials => credentials.Username);
        var adminPassword = credentials.Apply(credentials => credentials.Passwords[0].Value);

        var customImage = "estimationtool";
        var myImage = new Image(customImage, new ImageArgs
        {
            ImageName = Output.Format($"{registry.LoginServer}/{customImage}:v1.0.0"),
            Build = new DockerBuild { Context = "../.." },
            Registry = new ImageRegistry
            {
                Server = registry.LoginServer,
                Username = adminUsername,
                Password = adminPassword
            }
        });

        var containerApp = new ContainerApp("estimationtool", new ContainerAppArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ManagedEnvironmentId = managedEnv.Id,
            Configuration = new ConfigurationArgs
            {
                Ingress = new IngressArgs
                {
                    External = true,
                    TargetPort = 80
                },
                Registries =
                {
                    new RegistryCredentialsArgs
                    {
                        Server = registry.LoginServer,
                        Username = adminUsername,
                        PasswordSecretRef = "pwd",
                    }
                },
                Secrets =
                {
                    new SecretArgs
                    {
                        Name = "pwd",
                        Value = adminPassword
                    }
                },
            },
            Template = new TemplateArgs
            {
                Containers =
                {
                    new ContainerArgs
                    {
                        Name = "estimationtool",
                        Image = myImage.ImageName,
                    }
                }
            }
        });


        return registry;
    }
}
