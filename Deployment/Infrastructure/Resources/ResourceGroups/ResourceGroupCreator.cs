namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.ResourceGroups;

using Pulumi.Azure.Authorization;
using ResourceGroup = ResourceGroup;

internal static class ResourceGroupCreator
{
    internal static ResourceGroup Create(string enviromentName, Output<string> principalId)
    {
        var resourceGroup = new ResourceGroup($"rg-{enviromentName}-estimation-tool");
        var assignment = new Assignment($"a-rg-sp-{enviromentName}", new()
        {
            Scope = resourceGroup.Id,
            RoleDefinitionName = "Reader",
            PrincipalId = principalId
        });

        return resourceGroup;
    }
}
