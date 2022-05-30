[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance;

using Domain.Valuations.Queries.Projections;
using Domain.Valuations.Repositories;
using HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class PersistanceModule
{
    internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        // var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName);
        const string connectionString =
            "PORT = 5432; HOST = localhost; TIMEOUT = 15; POOLING = True; DATABASE = 'postgres'; PASSWORD = 'Password12!'; USER ID = 'postgres'";
        services.AddDataAccess(connectionString);
        services.AddPersistanceHealthChecks(connectionString);
        services.AddRepositories();
        services.AddProjections(connectionString);

        return services;
    }

    internal static void UsePersistanceModule(this IApplicationBuilder app)
    {
        app.UseDataAccess();
    }
}
