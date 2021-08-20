using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Swagger;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services,
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

            return services;
        }

        public static void UseSharedInfrastructure(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseSwaggerModule();
            app.UseCustomExceptionHandler();
            app.UseBackgroundProcessing();
        }
    }
}
