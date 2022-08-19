﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Api")]

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure;

using Application;
using Application.Common.Contracts;
using Events;
using Inquiries.Infrastructure.Snov;
using Mediation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Trello;

internal static class InfrastructureModule
{
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistanceModule(configuration);
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddEvents();
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
