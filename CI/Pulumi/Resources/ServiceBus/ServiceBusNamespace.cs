namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServiceBus;

using Pulumi.Azure.KeyVault;
using Pulumi.Azure.ServiceBus;
using Pulumi.AzureNative.AppConfiguration;

internal static class ServiceBusNamespace
{
    internal static Namespace Create(string enviromentName, ResourceGroup resourceGroup, KeyVault keyVault, ConfigurationStore appConfig)
    {
        var @namespace = new Namespace($"sb-{enviromentName}", new()
        {
            Location = resourceGroup.Location,
            ResourceGroupName = resourceGroup.Name,
            Sku = "Standard",
            Tags =
            {
                { nameof(enviromentName), enviromentName },
            }
        });
        var topic = new Topic($"sb-tc-{enviromentName}", new()
        {
            NamespaceId = @namespace.Id,
            EnablePartitioning = true,
        });

        var subscription = new Subscription($"sb-sn-{enviromentName}", new()
        {
            TopicId = topic.Id,
            MaxDeliveryCount = 1
        });

        return @namespace;
    }

}
