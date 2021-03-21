using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Swagger
{
    internal static class SwaggerModule
    {
        internal static void AddSwaggerModule(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("estimation-tool", new OpenApiInfo {Title = "API", Version = "v1.0"});
            });
        }

        internal static void UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/estimation-tool/swagger.json", "Users Module"); });
        }
    }
}