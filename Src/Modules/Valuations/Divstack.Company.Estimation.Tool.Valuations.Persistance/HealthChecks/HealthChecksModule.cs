namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksModule
{
    private const string DatabaseName = "Valuations Database";
    private const string Valuations = "Valuations";
    private const string Database = "Valuations";

    internal static IServiceCollection AddPersistanceHealthChecks(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddMongoDb(connectionString, DatabaseName, null, new[] { Valuations, Database });

        return services;
    }
}
