namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Cors;

using Configurations;
using Microsoft.AspNetCore.Builder;

internal static class CorsExtensions
{
    internal static void UseCors(this IApplicationBuilder app, IConfiguration configuration)
    {
        var corsConfiguration = new CorsConfiguration(configuration);
        app.UseCors(builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.WithOrigins(corsConfiguration.Origin);
            builder.AllowCredentials();
        });
    }
}
