using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Priorities.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Priorities.Persistance;

using DataAccess;
using HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class PersistanceModule
{
    private const string ConnectionStringName = "Priorities";
    internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        services.AddDataAccess(connectionString);
        services.AddPersistanceHealthChecks(connectionString);

        return services;
    }

    internal static void UsePersistanceModule(this IApplicationBuilder app) => app.UseDataAccess();
}
