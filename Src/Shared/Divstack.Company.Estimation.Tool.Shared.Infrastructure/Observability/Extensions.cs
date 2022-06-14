namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;
using Microsoft.AspNetCore.HttpLogging;

internal static class Extensions
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        services.AzureApplicationInsights();
        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.MediaTypeOptions.AddText("application/javascript");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;

        });
        return services;
    }
}
