namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware;

using Microsoft.AspNetCore.Builder;

internal static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
