namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ServicePrincipal;

using Pulumi.AzureAD;
using Pulumi.AzureAD.Inputs;

internal static class ServicePrincipalCreator
{
    internal static ServicePrincipal Create(string environment)
    {
        var clientConfig = Output.Create(GetClientConfig.InvokeAsync());
        var currentPrincipal = clientConfig.Apply(configResult => configResult.ObjectId);

        var application = new Application($"app-ad-{environment}", new()
        {
            AppRoles = new ApplicationAppRoleArgs[]
            {
                new()
                {
                    Id = "9e91ff68-b4e9-4ffd-ab18-6dd24a379a3b",
                    AllowedMemberTypes = new[] { "Application" },
                    Description = "Allows the application to access Estimation Tool API on behalf of the signed-in user.",
                    DisplayName = "Estimation Tool API",
                    Value = "estimation-tool-api",
                },
            },

            DisplayName = $"Estimation Tool - {environment}",
            Owners = new[]
            {
                currentPrincipal
            },
        });

        var servicePrincipal = new ServicePrincipal($"sp-ac-kv-{environment}-policy", new()
        {
            ApplicationId = application.ApplicationId,
            AppRoleAssignmentRequired = false,
            Owners = new[]
            {
                currentPrincipal
            },
        });

        return servicePrincipal;
    }
}
