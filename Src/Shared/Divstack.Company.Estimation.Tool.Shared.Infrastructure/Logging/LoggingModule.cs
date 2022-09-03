namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Logging;

using Decorators;
using MediatR;
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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingDecorator<,>));
    }

    internal static void UseLogging(this IApplicationBuilder app) => app.UseHttpLogging();
}
