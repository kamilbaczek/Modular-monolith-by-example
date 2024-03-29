﻿namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;

using Pulumi.Azure.Core;
using Pulumi.Azure.KeyVault;
using Pulumi.Azure.KeyVault.Inputs;
using ContainerApp = AzureNative.App.ContainerApp;
using ResourceGroup = ResourceGroup;

internal static class KeyVaultCreator
{
    internal static KeyVault Create(
        string enviroment,
        ResourceGroup resourceGroup,
        ConfigurationStore configurationStore,
        ContainerApp containerApp)
    {
        var clientConfig = Output.Create(GetClientConfig.InvokeAsync());
        var tenantId = clientConfig.Apply(c => c.TenantId);
        var currentPrincipal = clientConfig.Apply(c => c.ObjectId);

        var keyVault = new KeyVault($"kv-{enviroment}", new KeyVaultArgs
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
                    SecretPermissions =
                    {
                        "Delete", "Get", "List", "Set"
                    }
                },
                new KeyVaultAccessPolicyArgs
                {
                    TenantId = tenantId,
                    ObjectId = configurationStore.Identity.Apply(response => response!.PrincipalId),
                    SecretPermissions =
                    {
                        "Delete", "Get", "List", "Set"
                    }
                },
                new KeyVaultAccessPolicyArgs
                {
                    TenantId = tenantId,
                    ObjectId = containerApp.Identity.Apply(response => response!.PrincipalId),
                    SecretPermissions =
                    {
                        "Delete", "Get", "List", "Set"
                    }
                }
            }
        });

        return keyVault;
    }
}
