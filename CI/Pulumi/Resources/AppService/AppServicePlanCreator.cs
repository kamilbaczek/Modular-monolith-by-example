namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppService;

using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;

internal static class AppServicePlanCreator
{
    internal static Plan Create(string enviroment, ResourceGroup resourceGroup)
    {
        return new Plan($"plan-{enviroment}-free", new PlanArgs
        {
            Location = resourceGroup.Location,
            ResourceGroupName = resourceGroup.Name,
            Sku = new PlanSkuArgs
            {
                Tier = "Free",
                Size = "B2"
            },
            Tags =
            {
                {
                    nameof(enviroment), enviroment
                }
            }
        });
    }
}
