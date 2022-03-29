namespace Divstack.Company.Estimation.Tool.Users.Persistance.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksModule
{
    private const string DatabaseName = "Users Database";
    private const string Users = "Users";
    private const string Database = "Database";

    internal static IServiceCollection AddPersistanceHealthChecks(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddMySql(connectionString, DatabaseName, null, new[] { Users, Database });

        return services;
    }
}
