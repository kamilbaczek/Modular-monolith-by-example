namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ContainerApp;

using AzureNative.ContainerRegistry;
using AzureNative.OperationalInsights;
using AzureNative.OperationalInsights.Inputs;
using Pulumi.Azure.AppInsights;
using Pulumi.Azure.Role;
using Pulumi.Docker;
using ContainerApp = AzureNative.App.ContainerApp;
using ContainerArgs = ContainerArgs;
using SecretArgs = SecretArgs;
using SkuArgs = AzureNative.ContainerRegistry.Inputs.SkuArgs;

internal static class ContainerAppCreator
{
    [System.Obsolete]
    internal static ContainerApp Create(string environment,
        ResourceGroup resourceGroup,
        ConfigurationStore configurationStore,
        Insights insights)
    {
        var workspace = new Workspace($"{environment}-loganalytics", new WorkspaceArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Sku = new WorkspaceSkuArgs { Name = "PerGB2018" },
            RetentionInDays = 30
        });

        var configurationResult = Output.Tuple(resourceGroup.Name, configurationStore.Name)
            .Apply(items =>
                Pulumi.Azure.AppConfiguration.GetConfigurationStore.InvokeAsync(
                new()
                {
                    ResourceGroupName = items.Item1,
                    Name = items.Item2,
                }));

        var configurationStorePrimaryReadKeyResult = configurationResult.Apply(result => result.PrimaryReadKeys.First());

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
        var image = new Image(customImage, new ImageArgs
        {
            // ImageName = Output.Format($"{registry.LoginServer}/{customImage}:v1.0.0"),
            // Build = new DockerBuild { Context = "../.." },
            // Registry = new RegistryImage
            // {
            //     Server = registry.LoginServer,
            //     Username = adminUsername,
            //     Password = adminPassword
            // }
        });

        var containerApp = new ContainerApp("estimationtool", new ContainerAppArgs
        {
            ResourceGroupName = resourceGroup.Name,
            ManagedEnvironmentId = managedEnv.Id,
            Identity = new ManagedServiceIdentityArgs
            { Type = "SystemAssigned" },
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
                        Env = new InputList<EnvironmentVarArgs>
                        {
                            new EnvironmentVarArgs
                            {
                                Name = "ASPNETCORE_ENVIRONMENT",
                                Value = environment
                            },
                            new EnvironmentVarArgs
                            {
                                Name = "ConnectionStrings__AzureAppConfiguration",
                                Value = configurationStorePrimaryReadKeyResult.Apply(result => result.ConnectionString)
                            },
                            new EnvironmentVarArgs
                            {
                                Name = "ApplicationInsights__InstrumentationKey",
                                Value = insights.InstrumentationKey
                            },
                        },
                        Name = "estimationtool",
                        Image = image.ImageName,
                    }
                }
            }
        });

        var assignment = new Assignment($"ac-{environment}-do", new AssignmentArgs
        {
            Scope = configurationStore.Id,
            RoleDefinitionName = "App Configuration Data Owner",
            PrincipalId = containerApp.Identity.Apply(identity => identity.PrincipalId)
        });

        return containerApp;
    }
}
