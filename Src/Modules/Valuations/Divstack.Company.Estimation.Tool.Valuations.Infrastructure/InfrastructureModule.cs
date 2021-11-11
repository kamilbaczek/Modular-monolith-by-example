using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Domain.Configurations;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Mediation;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov;
using Divstack.Company.Estimation.Tool.Valuations.Application;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello;
using Divstack.Company.Estimation.Tool.Valuations.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Api")]

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure;

internal static class InfrastructureModule
{
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistanceModule(configuration);
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddEvents();
        services.AddDeadlines();
        services.AddTrello();
        services.AddSnov();
        services.AddScoped<IValuationsModule, ValuationsModule>();

        return services;
    }

    internal static void UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseTrello();
        app.UsePersistanceModule();
    }
}
