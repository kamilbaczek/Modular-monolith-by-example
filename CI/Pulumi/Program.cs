using System.Collections.Generic;
using System.Linq;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppInsights;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Deployment = Pulumi.Deployment;

IEnumerable<string> GetEnviroments()
{
    var enviroments = new List<string>
    {
        "Stage"
    }
    .Select(name => name.ToLower());

    return enviroments;
}

ResourceGroup ResourceGroup(string enviroment) => new($"rg-{enviroment}-estimation-tool");


return await Deployment.RunAsync(() =>
{
    var environments = GetEnviroments();

    var pulumiConfig = new Config();
    foreach (var environment in environments)
    {
        var resourceGroup = ResourceGroup(environment);
        var appServicePlan = AppServicePlanCreator.Create(environment, resourceGroup);
        var keyVault = KeyVaultCreator.Create(environment, resourceGroup);
        var configurationStore = AppConfigurationCreator.Create(environment, resourceGroup);
        var estimationToolApiAppInsights = AppInsightsCreator.Create(environment, resourceGroup);
        var estimationToolApi = AppServiceCreator.Create(environment, estimationToolApiAppInsights, pulumiConfig, resourceGroup, appServicePlan);
    }
});
