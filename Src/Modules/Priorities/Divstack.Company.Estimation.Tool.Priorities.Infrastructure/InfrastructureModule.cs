using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Priorities.Api")]

namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure;

using Common.Contracts;
using Domain.BackgroundProcesses;
using Domain.Configurations;
using Domain.Services;
using Events;
using Mediation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance;

internal static class InfrastructureModule
{
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistanceModule(configuration);
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddBackgroundProcesses();
        services.AddEvents();
        services.AddDeadlines();
        services.AddDomainServices();
        services.AddScoped<IPrioritiesModule, PrioritiesModule>();

        return services;
    }

    internal static void UseInfrastructure(this IApplicationBuilder app)
    {
        app.UsePersistanceModule();
    }
}
