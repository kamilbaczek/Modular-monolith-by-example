using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllersFeatureProvider());
                });

            services.AddSwaggerModule();
            services.AddMvcCore();
            services.AddCors();

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
        }
    }
}