namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability.Middleware;

using Microsoft.AspNetCore.Builder;

internal static class TelemetryMiddlewareMiddlewareExtensions
{
    public static IApplicationBuilder UseTelemetry(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TelemetryMiddleware>();
    }
}
