namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServicePrincipal;

using Pulumi.AzureAD;

internal static class ServicePrincipalCreator
{
    internal static ServicePrincipal Create(string environment)
    {
        var clientConfig = Output.Create(GetClientConfig.InvokeAsync());
        var currentPrincipal = clientConfig.Apply(configResult => configResult.ObjectId);

        var application = new Application($"app-ad-{environment}", new()
        {
            DisplayName = $"Estimation Tool - {environment}",
        });

        var servicePrincipal = new ServicePrincipal($"sp-ac-kv-{environment}-policy", new()
        {
            ApplicationId = application.ApplicationId,
            AppRoleAssignmentRequired = false,
        });

        return servicePrincipal;
    }
}
