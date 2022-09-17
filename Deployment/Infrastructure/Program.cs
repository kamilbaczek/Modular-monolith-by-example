using Divstack.Estimation.Tool.Deployment.Infrastructure.Common.Enviroments;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppInsights;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ResourceGroups;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServiceBus;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServicePrincipal;
using Deployment = Pulumi.Deployment;

return await Deployment.RunAsync(() =>
{
    var environments = DeployEnvironments.All;
    var pulumiConfig = new Config();

    foreach (var environment in environments)
        CreateResources(environment, pulumiConfig);
});

void CreateResources(string environment, Config configuration)
{
    var servicePrincipal = ServicePrincipalCreator.Create(environment);
    var resourceGroup = ResourceGroupCreator.Create(environment, servicePrincipal.ObjectId);
    var appServicePlan = AppServicePlanCreator.Create(environment, resourceGroup);
    var @namespace = ServiceBusNamespace.Create(environment, resourceGroup);
    var configurationStore = AppConfigurationCreator.Create(environment, resourceGroup);
    var keyVault = KeyVaultCreator.Create(environment, resourceGroup, configuration);
    SecuredKeyValueCreator.Create(environment, keyVault, configuration, resourceGroup, configurationStore, @namespace);
    var appInsights = AppInsightsCreator.Create(environment, resourceGroup);
    ContainerAppCreator.Create(environment, appInsights, configuration, resourceGroup, appServicePlan);
}
