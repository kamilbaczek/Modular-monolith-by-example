namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksModule
{
    private const string DatabaseName = "Priorities Database";
    private const string Tag = "Priorities";
    internal static IServiceCollection AddPersistanceHealthChecks(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddMongoDb(connectionString, DatabaseName, null, new[] { Tag }, null);

        return services;
    }
}
