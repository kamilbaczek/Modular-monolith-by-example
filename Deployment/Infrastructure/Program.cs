using Divstack.Estimation.Tool.Deployment.Infrastructure.Common.Enviroments;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;
using Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;
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
    var objetId = current.Apply(getClientConfigResult => getClientConfigResult.ObjectId);
    var resourceGroup = ResourceGroupCreator.Create(environment, objetId);
    var @namespace = ServiceBusNamespace.Create(environment, resourceGroup);
    var configurationStoreResult = AppConfigurationCreator.Create(environment, resourceGroup);
    var keyVault = KeyVaultCreator.Create(environment, resourceGroup, configuration);
    SecuredKeyValueCreator.Create(environment, keyVault, configuration, resourceGroup, configurationStoreResult.ConfigurationStore, @namespace, configurationStoreResult.Assigment);
    ContainerAppCreator.Create(environment, resourceGroup);
}
