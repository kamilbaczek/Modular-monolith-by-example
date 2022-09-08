namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;

using Pulumi.Azure.AppConfiguration;
using ConfigurationStore = Pulumi.AzureNative.AppConfiguration.ConfigurationStore;
using ConfigurationStoreArgs = Pulumi.AzureNative.AppConfiguration.ConfigurationStoreArgs;
using SkuArgs = Pulumi.AzureNative.AppConfiguration.Inputs.SkuArgs;

internal static class AppConfigurationCreator
{
    internal static ConfigurationStore Create(string enviroment, ResourceGroup resourceGroup)
    {
        var configurationStore = CreateStore(enviroment, resourceGroup);
        foreach (var keyValue in AppConfigurationKeys.NotSecuredKeys)
            CreateConfigurationKey(enviroment, keyValue, configurationStore);
        foreach (var keyValue in AppConfigurationKeys.FeatureFlags)
            CreateFeatureFlag(enviroment, keyValue, configurationStore);

        return configurationStore;
    }
    private static ConfigurationStore CreateStore(string enviroment, ResourceGroup resourceGroup)
    {
        return new ConfigurationStore($"ac-{enviroment}", new ConfigurationStoreArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = new SkuArgs
            {
                Name = "Standard",
            },
        });
    }
    private static void CreateConfigurationKey(string enviroment, KeyValuePair<string, string> keyValue, ConfigurationStore configurationStore)
    {
        var configurationKey = new ConfigurationKey(keyValue.Key, new ConfigurationKeyArgs
        {
            ConfigurationStoreId = configurationStore.Id,
            Key = keyValue.Key,
            Label = enviroment,
            Value = keyValue.Value
        });
    }

    private static void CreateFeatureFlag(string enviroment, KeyValuePair<string, bool> keyValue, ConfigurationStore configurationStore)
    {
        var configurationKey = new ConfigurationFeature(keyValue.Key, new ConfigurationFeatureArgs()
        {
            ConfigurationStoreId = configurationStore.Id,
            Description = string.Empty,
            Name = keyValue.Key,
            Label = enviroment,
            Enabled = keyValue.Value,
        });
    }
}
