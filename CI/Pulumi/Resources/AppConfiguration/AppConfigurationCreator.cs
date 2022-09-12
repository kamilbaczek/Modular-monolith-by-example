namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;

using AzureNative.Authorization;
using Pulumi.Azure.AppConfiguration;
using Pulumi.Azure.Authorization;
using ConfigurationStore = Pulumi.AzureNative.AppConfiguration.ConfigurationStore;
using ConfigurationStoreArgs = Pulumi.AzureNative.AppConfiguration.ConfigurationStoreArgs;
using SkuArgs = Pulumi.AzureNative.AppConfiguration.Inputs.SkuArgs;

internal static class AppConfigurationCreator
{
    internal static ConfigurationStore Create(string enviroment, ResourceGroup resourceGroup)
    {
        var configurationStore = CreateStore(enviroment, resourceGroup);
        var current = GetClientConfig.InvokeAsync().Result;
        var dataowner = new Assignment($"ac-{enviroment}-do", new AssignmentArgs
        {
            Scope = configurationStore.Id,
            RoleDefinitionName = "App Configuration Data Owner",
            PrincipalId = current.ObjectId
        });

        foreach (var keyValue in AppConfigurationKeys.NotSecuredKeys)
            CreateConfigurationKey(enviroment, keyValue, configurationStore, dataowner);
        foreach (var keyValue in AppConfigurationKeys.FeatureFlags)
            CreateFeatureFlag(enviroment, keyValue, configurationStore, dataowner);

        return configurationStore;
    }
    private static ConfigurationStore CreateStore(string enviroment, ResourceGroup resourceGroup)
    {
        var configurationStore = new ConfigurationStore($"ac-{enviroment}", new ConfigurationStoreArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = new SkuArgs
            {
                Name = "Standard",
            },
        });

        return configurationStore;
    }

    private static void CreateConfigurationKey(string enviroment, KeyValuePair<string, string> keyValue, ConfigurationStore configurationStore, Assignment assignment)
    {
        var configurationKey = new ConfigurationKey(keyValue.Key, new ConfigurationKeyArgs
        {
            ConfigurationStoreId = configurationStore.Id,
            Key = keyValue.Key,
            Label = enviroment,
            Value = keyValue.Value
        },
            new CustomResourceOptions
            {
                DependsOn = new[]
                {
                    assignment
                }
            });
    }

    private static void CreateFeatureFlag(string enviroment, KeyValuePair<string, bool> keyValue, ConfigurationStore configurationStore, Assignment assignment)
    {
        var configurationKey = new ConfigurationFeature(keyValue.Key, new ConfigurationFeatureArgs()
        {
            ConfigurationStoreId = configurationStore.Id,
            Description = string.Empty,
            Name = keyValue.Key,
            Label = enviroment,
            Enabled = keyValue.Value,
        },
            new CustomResourceOptions
            {
                DependsOn = new[]
                {
                    assignment
                }
            });
    }
}
