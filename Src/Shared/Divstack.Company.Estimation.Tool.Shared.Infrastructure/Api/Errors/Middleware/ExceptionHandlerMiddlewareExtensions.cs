namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware;

using Microsoft.AspNetCore.Builder;

internal static class ExceptionHandlerMiddlewareExtensions
{
    internal static void UseExceptionHandling(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ErrorHandling>();
    }
}
