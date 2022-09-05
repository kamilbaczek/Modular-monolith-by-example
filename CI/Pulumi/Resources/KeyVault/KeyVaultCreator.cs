namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;

using Pulumi.Azure.KeyVault;
using Pulumi.AzureNative.Resources;

internal static class KeyVaultCreator
{
    internal static KeyVault Create(string enviroment, ResourceGroup resourceGroup)
    {
        var keyVault = new KeyVault($"kv-{enviroment}", new()
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            EnabledForDeployment = true,
            EnabledForDiskEncryption = true,
            EnabledForTemplateDeployment = true,
            SkuName = "Standard",
        });

        return keyVault;
    }
}
