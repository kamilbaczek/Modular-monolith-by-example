using System.Collections.Generic;
using System.Linq;
using Divstack.Estimation.Tool.Deplyoment.Infrastructure.Resources.AppConfiguration;
using Divstack.Estimation.Tool.Deplyoment.Infrastructure.Resources.AppInsights;
using Divstack.Estimation.Tool.Deplyoment.Infrastructure.Resources.AppService;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Deployment = Pulumi.Deployment;

IEnumerable<string> GetEnviroments()
{
    var enumerable = new List<string>
    {
        "Stage"
    }.Select(name => name.ToLower());

    return enumerable;
}

ResourceGroup ResourceGroup(string enviroment)
{
    return new ResourceGroup($"rg-{enviroment}-estimation-tool");
}


return await Deployment.RunAsync(() =>
{
    var environments = GetEnviroments();

    var pulumiConfig = new Config();
    foreach (var environment in environments)
    {
        var resourceGroup = ResourceGroup(environment);
        var appServicePlan = AppServicePlanCreator.Create(environment, resourceGroup);
        var configurationStore = AppConfigurationCreator.Create(environment, resourceGroup);
        var estimationToolApiAppInsights = AppInsightsCreator.Create(environment, resourceGroup);
        var estimationToolApi = AppServiceCreator.Create(environment, estimationToolApiAppInsights, pulumiConfig, resourceGroup, appServicePlan);
    }
});

//
// var vault = new KeyVault("vault", new()
//     {
//         ResourceGroupName = resourceGroup.Name,
//         Sku = new SkuArgs
//         {
//             Name = SkuName.Standard,
//         },
//         TenantId = pulumiConfig.Require("tenantId"),
//         AccessPolicies = new[]
//         {
//             new AccessPolicyEntryArgs
//             {
//                 Permissions = new PermissionsArgs
//                 {
//                     Keys = new[] {"get", "list", "create", "update", "import", "delete", "backup", "restore", "recover"},
//                     Secrets = new[] {"get", "list", "set", "delete", "backup", "restore", "recover"},
//                     Certificates = new[] {"get", "list", "delete", "create", "import", "update", "managecontacts", "getissuers", "listissuers", "setissuers", "deleteissuers", "manageissuers", "recover"},
//                     Storage = new[] {"get", "list", "delete", "set", "update", "regeneratekey", "setsas", "listsas", "getsas", "deletesas"},
//                 },
//             },
//         },
//         Location = "westus",
//
//         EnabledForDeployment = true,
//         EnabledForDiskEncryption = true,
//         EnabledForTemplateDeployment = true,
//         Sku = new SkuArgs
//         {
//             Family = "A",
//             Name = SkuName.Standard,
//         },
//         TenantId = "00000000-0000-0000-0000-000000000000",
//     },
//     ResourceGroupName = "sample-resource-group",
//     VaultName = "sample-vault",
// });
