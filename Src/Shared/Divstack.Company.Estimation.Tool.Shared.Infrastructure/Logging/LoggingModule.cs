namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Logging;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;

internal static class LoggingModule
{
    private const string ContentType = "application/javascript";

    internal static void AddLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
                                    HttpLoggingFields.RequestBody;
            logging.MediaTypeOptions.AddText(ContentType);
        });
    }

    internal static void UseLogging(this IApplicationBuilder app) => app.UseHttpLogging();
}
