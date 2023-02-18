namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;

using Pulumi.Azure.AppConfiguration;
using Pulumi.Azure.Authorization;
using Pulumi.Azure.KeyVault;
using Pulumi.Azure.ServiceBus;
using Secrets;
using ConfigurationStore = ConfigurationStore;
using ResourceGroup = ResourceGroup;
using Secret = Pulumi.AzureNative.KeyVault.Secret;
using SecretArgs = Pulumi.AzureNative.KeyVault.SecretArgs;

internal static class SecuredKeyValueCreator
{
    private const string ServiceBusSecretName = "ServiceBusConnectionString";
    private const string EventbusConnectionString = "EventBus:ConnectionString";

    internal static IReadOnlyCollection<Secret> Create(string enviroment,
        KeyVault keyVault,
        Config config,
        ResourceGroup resourceGroup,
        ConfigurationStore configurationStore,
        Namespace @namespace,
        Assignment assignment)
    {
        var secrets = new List<Secret>();
        foreach (var keyVaultSecret in KeyVaultSecrets.Secrets)
        {
            var createdSecret = CreateSecret(keyVault, config, resourceGroup, keyVaultSecret);
            secrets.Add(createdSecret);

            foreach (var securedAppConfigKey in keyVaultSecret.SecuredAppConfigKeys)
                CreateConfigurationForSecret(enviroment, securedAppConfigKey.Key, createdSecret, configurationStore, assignment);
        }

        CreateServiceBusSecret(
            enviroment,
            keyVault,
            resourceGroup,
            configurationStore,
            @namespace,
            secrets,
            assignment);

        return secrets;
    }

    private static void CreateServiceBusSecret(string enviroment, KeyVault keyVault, ResourceGroup resourceGroup, ConfigurationStore configurationStore, Namespace @namespace, List<Secret> secrets, Assignment assignment)
    {
        var secret = new Secret(ServiceBusSecretName,
            new SecretArgs
            {
                Properties = new AzureNative.KeyVault.Inputs.SecretPropertiesArgs
                {
                    Value = @namespace.DefaultPrimaryConnectionString
                },
                ResourceGroupName = resourceGroup.Name,
                SecretName = ServiceBusSecretName,
                VaultName = keyVault.Name,
            });
        secrets.Add(secret);
        CreateConfigurationForSecret(enviroment, EventbusConnectionString, secret, configurationStore, assignment);
    }

    private static Secret CreateSecret(KeyVault keyVault, Config config, ResourceGroup resourceGroup, KeyVaultSecret keyVaultSecret)
    {
        var secretValue = config.Require(keyVaultSecret.Name);

        return new Secret(keyVaultSecret.Name,
            new SecretArgs
            {
                Properties = new AzureNative.KeyVault.Inputs.SecretPropertiesArgs
                {
                    Value = secretValue
                },
                ResourceGroupName = resourceGroup.Name,
                SecretName = keyVaultSecret.Name,
                VaultName = keyVault.Name,
            });
    }

    private static void CreateConfigurationForSecret(string enviroment, string key, Secret secret, ConfigurationStore configurationStore, Assignment assignment)
    {
        var configurationKey = new ConfigurationKey(key,
        new ConfigurationKeyArgs
        {
            ConfigurationStoreId = configurationStore.Id,
            Key = key,
            Label = enviroment,
            Type = "vault",
            VaultKeyReference = secret.Properties.Apply(response => response.SecretUriWithVersion),
        }, new CustomResourceOptions
        {
            DependsOn = assignment
        });
    }
}
