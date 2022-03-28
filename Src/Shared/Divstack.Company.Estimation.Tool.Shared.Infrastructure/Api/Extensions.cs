using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api;

using BackgroundProcessing;
using Controllers;
using Cors;
using Errors.Middleware;
using HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Observability;
using Persistance;
using Swagger;
using WebSockets;

internal static class Extensions
{
    internal static IServiceCollection AddSharedInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddInternalControllers();
        services.AddHttpClient();
        services.AddSwaggerModule();
        services.AddMvcCore();
        services.AddCors();
        services.AddBackgroundProcessing(configuration);
        services.AddSharedHealthChecks();
        services.AddObservability();

        return services;
    }

    internal static void UseSharedInfrastructure(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
        app.UseCors(configuration);
        app.UseWebSockets(configuration);
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwaggerModule();
        app.UseCustomExceptionHandler();
        app.UseBackgroundProcessing();
        app.UseObservability();
        app.UseSharedPersistance();
        app.UseSharedHealthChecks();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSharedHealthChecks();
        });
    }

    public static void ConfigureSharedInfrastructure(this IWebHostBuilder hostBuilder)
    {
        hostBuilder.UseObservability();
    }
}
