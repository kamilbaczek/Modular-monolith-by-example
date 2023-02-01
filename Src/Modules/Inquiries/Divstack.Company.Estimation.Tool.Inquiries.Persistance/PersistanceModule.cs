[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance;

using DataAccess;
using HealthChecks;
using Microsoft.Extensions.Configuration;
using Repositories;

internal static class PersistanceModule
{
    internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName)!;
        services.AddDataAccess(connectionString);
        services.AddPersistanceHealthChecks(connectionString);
        services.AddRepositories();

        return services;
    }
}
