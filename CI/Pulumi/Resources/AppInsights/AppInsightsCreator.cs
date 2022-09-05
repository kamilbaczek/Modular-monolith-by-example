namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppInsights;

using System.Collections.Generic;
using Pulumi.Azure.AppInsights;
using Pulumi.AzureNative.Resources;

internal static class AppInsightsCreator
{
    internal static Insights Create(string enviroment, ResourceGroup resourceGroup)
    {
        return new Insights($"ai-{enviroment}-api", new InsightsArgs
        {
            ApplicationType = "web",
            DailyDataCapInGb = 100,
            Location = resourceGroup.Location,
            ResourceGroupName = resourceGroup.Name,
            SamplingPercentage = 0,
            Tags = new Dictionary<string, string>
            {
                {
                    nameof(enviroment), enviroment
                }
            }
        });
    }
}
