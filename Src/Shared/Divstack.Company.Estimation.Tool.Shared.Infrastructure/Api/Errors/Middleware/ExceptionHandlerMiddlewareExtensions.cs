using Microsoft.AspNetCore.Builder;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware;

internal static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
