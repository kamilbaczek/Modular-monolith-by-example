﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Payments.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Payments.Persistance;

using DataAccess;
using Domain.Payments.Repositories;
using HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class PersistanceModule
{
    internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName);
        services.AddDataAccess(connectionString);
        services.AddPersistanceHealthChecks(connectionString);
        services.AddRepositories();

        return services;
    }

    internal static void UsePersistanceModule(this IApplicationBuilder app)
    {
        PersistanceConfiguration.Configure();
    }
}
