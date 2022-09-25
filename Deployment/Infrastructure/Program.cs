using Divstack.Estimation.Tool.Deployment.Infrastructure.Common.Enviroments;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppInsights;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ContainerApp;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ResourceGroups;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServiceBus;
using Pulumi.AzureAD;
using Config = Pulumi.Config;
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
    var current = Output.Create(GetClientConfig.InvokeAsync());
    var principalId = current.Apply(getClientConfigResult => getClientConfigResult.ObjectId);

    var resourceGroup = ResourceGroupCreator.Create(environment, principalId);
    var @namespace = ServiceBusNamespace.Create(environment, resourceGroup);
    var configurationStoreResult = AppConfigurationCreator.Create(environment, resourceGroup);
    var applicationInsights = AppInsightsCreator.Create(environment, resourceGroup);
    var containerApp = ContainerAppCreator.Create(environment, resourceGroup, configurationStoreResult.ConfigurationStore, applicationInsights);
    var keyVault = KeyVaultCreator.Create(environment, resourceGroup, configurationStoreResult.ConfigurationStore, containerApp);
    SecuredKeyValueCreator.Create(environment,
        keyVault,
        configuration,
        resourceGroup,
        configurationStoreResult.ConfigurationStore,
        @namespace,
        configurationStoreResult.Assigment);
}
