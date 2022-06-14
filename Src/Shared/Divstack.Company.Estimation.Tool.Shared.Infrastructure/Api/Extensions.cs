[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api;

using BackgroundProcessing;
using Configuration;
using Controllers;
using Cors;
using Errors.Middleware;
using EventBus;
using HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Observability;
using Persistance;
using Swagger;
using WebSockets;

internal static class Extensions
{
    internal static void AddSharedInfrastructure(this IServiceCollection services,
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
        services.AddConfiguration();
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
        app.UseExceptionHandling();
        app.UseBackgroundProcessing();
        app.UseSharedPersistance();
        app.UseSharedHealthChecks();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSharedHealthChecks();
        });
    }

    internal static IHostBuilder UseSharedInfrastructure(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseEvents();

        return hostBuilder;
    }
}
