using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api;

using BackgroundProcessing;
using Configurations;
using Errors.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Observability;
using Persistance;
using Swagger;

internal static class Extensions
{
    internal static IServiceCollection AddSharedInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new InternalControllersFeatureProvider());
            });

        services.AddHttpClient();
        services.AddSwaggerModule();
        services.AddMvcCore();
        services.AddCors();
        services.AddBackgroundProcessing();
        services.AddObservability();

        return services;
    }

    internal static void UseSharedInfrastructure(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
        var corsConfiguration = new CorsConfiguration(configuration);
        app.UseCors(builder => builder
            .WithOrigins(corsConfiguration.Origin)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseSwaggerModule();
        app.UseCustomExceptionHandler();
        app.UseBackgroundProcessing();
        app.UseObservability();
        app.UseSharedPersistance();
    }

    public static void ConfigureSharedInfrastructure(this IWebHostBuilder hostBuilder)
    {
        hostBuilder.UseObservability();
    }
}
