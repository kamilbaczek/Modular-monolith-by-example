namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Swagger;

using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

internal static class SwaggerModule
{
    internal static void AddSwaggerModule(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            var projectName = Assembly.GetEntryAssembly()?.GetName().Name;
            swagger.AddJwtAuthorization();
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("api", new OpenApiInfo
            {
                Title = "API",
                Version = "v1.1"
            });
            var xmlFile = $"{projectName}.xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            swagger.IncludeXmlComments(xmlFilePath);
        });
    }

    internal static void UseSwaggerModule(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("/swagger/api/swagger.json", "Estimation Tool");
        });
    }
}
