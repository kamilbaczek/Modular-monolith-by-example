using System.Collections.Generic;
using System.Linq;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppInsights;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ResourceGroups;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServicePrincipal;
using Pulumi;
using Deployment = Pulumi.Deployment;

IEnumerable<string> GetEnvironments()
{
    var environments = new List<string>
    {
        "Stage"
    }
    .Select(name => name.ToLower());

    return environments;
}

return await Deployment.RunAsync(() =>
{
    var environments = GetEnvironments();
    var pulumiConfig = new Config();

    foreach (var environment in environments)
        CreateResources(environment, pulumiConfig);
});

void CreateResources(string environment, Config config)
{
    var servicePrincipal = ServicePrincipalCreator.Create(environment);
    var resourceGroup = ResourceGroupCreator.Create(environment, servicePrincipal.ObjectId);
    var appServicePlan = AppServicePlanCreator.Create(environment, resourceGroup);
    var keyVault = KeyVaultCreator.Create(environment, resourceGroup, config);
    var configurationStore = AppConfigurationCreator.Create(environment, keyVault.Id, resourceGroup);
    var appInsights = AppInsightsCreator.Create(environment, resourceGroup);
    var api = AppServiceCreator.Create(environment, appInsights, config, resourceGroup, appServicePlan);
}
