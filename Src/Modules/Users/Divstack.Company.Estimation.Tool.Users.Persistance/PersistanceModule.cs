using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Users.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Users.Persistance;

using DataAccess;
using HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

internal static class PersistanceModule
{
    private const string UsersConnectionString = "Users";

    internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(UsersConnectionString);
        services.AddDataAccess(connectionString);
        services.AddPersistanceHealthChecks(connectionString);
        services.AddRepositories();

        return services;
    }
}
