namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;

using System.Collections.Generic;
using Pulumi;
using Pulumi.Azure.AppConfiguration;
using Pulumi.Azure.Authorization;
using Pulumi.AzureNative.Resources;
using ConfigurationStore = Pulumi.AzureNative.AppConfiguration.ConfigurationStore;
using ConfigurationStoreArgs = Pulumi.AzureNative.AppConfiguration.ConfigurationStoreArgs;
using GetClientConfig = Pulumi.AzureNative.Authorization.GetClientConfig;
using SkuArgs = Pulumi.AzureNative.AppConfiguration.Inputs.SkuArgs;

internal static class AppConfigurationCreator
{
    private static List<string> Secret => new List<string>
    {
        "TokenConfiguration:Secret"
    };

    private static IDictionary<string, string> Values => new Dictionary<string, string>
    {
        {
            "Priority:Deadline:WorksDaysToDeadlineFromNow", ""
        },
        {
            "TokenConfiguration:Issuer", "localhost:5001"
        },
        {
            "TokenConfiguration:Audience", "DeveloperAudience"
        },
        {
            "TokenConfiguration:AccessExpirationInMinutes", "10000000"
        },
        {
            "TokenConfiguration:RefreshExpirationInMinutes", "100000"
        },
        {
            "TokenConfiguration:LinksExpirationInMinutes", "15"
        },
        {
            "Users:PasswordExpirationFrequency", "30"
        },
        {
            "AdminAccount:UserName", "admin@divstack.pl"
        },
        {
            "AdminAccount:Email", "admin@divstack.pl"
        },
        {
            "AdminAccount:Password", "3wsx$EDC5rfvtest4"
        },
        {
            "AdminAccount:Init", "true"
        },
    };

    private static IDictionary<string, bool> FeatureFlags => new Dictionary<string, bool>
    {
        {
            "InquiriesModule", true
        },
        {
            "UsersModule", true
        },
        {
            "PaymentsModule", true
        },
        {
            "ValuationsModule", true
        },
        {
            "PrioritiesModule", true
        },
    };

    internal static ConfigurationStore Create(string enviroment, Output<string> valutId, ResourceGroup resourceGroup)
    {
        var clientConfig = Output.Create(GetClientConfig.InvokeAsync());

        var configurationStore = new ConfigurationStore($"ac-{enviroment}", new ConfigurationStoreArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = new SkuArgs
            {
                Name = "Standard",
            },
        });

        var assignment = new Assignment($"ac-{enviroment}-do", new AssignmentArgs
        {
            Scope = configurationStore.Id,
            RoleDefinitionName = "App Configuration Data Owner",
            PrincipalId = clientConfig.Apply(result => result.ObjectId)
        });

        foreach (var keyValue in Values)
            CreateConfigurationKey(enviroment, keyValue, configurationStore, assignment);
        foreach (var keyValue in FeatureFlags)
            CreateFeatureFlag(enviroment, keyValue, configurationStore, assignment);

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
        var configurationKey = new ConfigurationFeature(keyValue.Key, new ConfigurationFeatureArgs()
        {
            ConfigurationStoreId = configurationStore.Id,
            Description = string.Empty,
            Name = keyValue.Key,
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
