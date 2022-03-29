namespace Divstack.Company.Estimation.Tool.Payments.Persistance.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksModule
{
    private const string DatabaseName = "Payments Database";
    private const string Tag = "Payments";
    private const string Database = "Database";

    internal static IServiceCollection AddPersistanceHealthChecks(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddMongoDb(connectionString, DatabaseName, null, new[] { Tag, Database }, null);

        return services;
    }
}
