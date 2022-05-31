namespace Divstack.Company.Estimation.Tool.Services.DataAccess.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksModule
{
    private const string DatabaseName = "Services Database";
    private const string Services = "Services";
    private const string Database = "Database";
    internal static IServiceCollection AddDataAccessHealthChecks(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddMySql(connectionString, DatabaseName, null, new[]
        {
            Services, Database
        });

        return services;
    }
}
