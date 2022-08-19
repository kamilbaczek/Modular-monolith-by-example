using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Telemetry;

using Microsoft.Extensions.DependencyInjection;

public static class AzureApplicationInsightsModule
{
    internal static void AzureApplicationInsights(this IServiceCollection services)
    {
        //TODO: Connect to Azure Application Insights
        // services.AddApplicationInsightsTelemetry();
    }
}
