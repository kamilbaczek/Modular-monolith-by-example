namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;

using System.Collections.Generic;
using Pulumi;
using Pulumi.Azure.AppConfiguration;
using Pulumi.Azure.Authorization;
using Pulumi.AzureNative.Authorization;
using Pulumi.AzureNative.Resources;
using ConfigurationStore = Pulumi.AzureNative.AppConfiguration.ConfigurationStore;
using ConfigurationStoreArgs = Pulumi.AzureNative.AppConfiguration.ConfigurationStoreArgs;
using SkuArgs = Pulumi.AzureNative.AppConfiguration.Inputs.SkuArgs;

internal static class AppConfigurationCreator
{
    private static IDictionary<string, string> Values => new Dictionary<string, string>
    {
        {
            "Priority:Deadline:WorksDaysToDeadlineFromNow", ""
        },
        {
            "ConnectionStrings:Priorities", ""
        }
    };

    private static IDictionary<string, bool> FeatureFlags => new Dictionary<string, bool>
    {
        {
            "FeatureManagement:InquiriesModule", true
        },
        {
            "FeatureManagement:PaymentsModule", true
        },
        {
            "FeatureManagement:ValuationsModule", true
        },
        {
            "FeatureManagement:PrioritiesModule", true
        },
    };

    internal static ConfigurationStore Create(string enviroment, ResourceGroup resourceGroup)
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

        var current = GetClientConfig.InvokeAsync().Result;
        var dataowner = new Assignment($"ac-{enviroment}-do", new AssignmentArgs
        {
            Scope = configurationStore.Id,
            RoleDefinitionName = "App Configuration Data Owner",
            PrincipalId = current.ObjectId
        });

        foreach (var keyValue in Values)
            CreateConfigurationKey(enviroment, keyValue, configurationStore, dataowner);
        foreach (var keyValue in FeatureFlags)
            CreateFeatureFlag(enviroment, keyValue, configurationStore, dataowner);

        return configurationStore;
    }
    private static void CreateConfigurationKey(string enviroment, KeyValuePair<string, string> keyValue, ConfigurationStore configurationStore, Assignment dataowner)
    {
        var configurationKey = new ConfigurationKey(keyValue.Key, new ConfigurationKeyArgs
        {
            ConfigurationStoreId = configurationStore.Id,
            Key = keyValue.Key,
            Label = enviroment,
            Value = keyValue.Value
        }, new CustomResourceOptions
        {
            DependsOn = new[]
            {
                dataowner
            }
        });
    }

    private static void CreateFeatureFlag(string enviroment, KeyValuePair<string, bool> keyValue, ConfigurationStore configurationStore, Assignment dataowner)
    {
        var configurationKey = new ConfigurationFeature("key", new ConfigurationFeatureArgs()
        {
            ConfigurationStoreId = configurationStore.Id,
            Description = keyValue.Key,
            Label = enviroment,
            Enabled = keyValue.Value,
        }, new CustomResourceOptions
        {
            DependsOn = new[]
            {
                dataowner
            }
        });
    }
}
