namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;

using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.KeyVault;
using Pulumi.Azure.KeyVault.Inputs;
using AzureNative = Pulumi.AzureNative;
using ResourceGroup = Pulumi.AzureNative.Resources.ResourceGroup;

internal static class KeyVaultCreator
{
    internal static KeyVault Create(string enviroment, ResourceGroup resourceGroup, Config config)
    {
        var clientConfig = Output.Create(GetClientConfig.InvokeAsync());
        var tenantId = clientConfig.Apply(c => c.TenantId);
        var currentPrincipal = clientConfig.Apply(c => c.ObjectId);

        var keyVault = new KeyVault($"kv-{enviroment}", new()
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            EnabledForDeployment = true,
            EnabledForDiskEncryption = true,
            EnabledForTemplateDeployment = true,
            SkuName = "standard",
            TenantId = tenantId,
            AccessPolicies =
            {
                new KeyVaultAccessPolicyArgs
                {
                    TenantId = tenantId,
                    ObjectId = currentPrincipal,
                    SecretPermissions = {"Delete", "Get", "List", "Set"},
                }
            },
        });

        foreach (var secretName in KeyVaultSecrets.Secrets)
        {
            var secret = new AzureNative.KeyVault.Secret(secretName, new()
            {
                Properties = new AzureNative.KeyVault.Inputs.SecretPropertiesArgs
                {
                    Value = config.RequireSecret(secretName),
                },
                ResourceGroupName = resourceGroup.Name,
                SecretName = secretName,
                VaultName = keyVault.Name,
            });
        }

        return keyVault;
    }
}
