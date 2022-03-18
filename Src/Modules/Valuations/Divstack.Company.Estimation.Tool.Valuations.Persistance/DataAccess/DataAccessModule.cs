namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddMongo(connectionString);
        services.AddScoped<IValuationsNotificationsContext, ValuationsNotificationsNotificationsContext>();

        return services;
    }

    private static void AddMongo(this IServiceCollection services, string connectionString)
    {
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        var mongoClient = new MongoClient(settings);

        services.AddSingleton(mongoClient);
    }

    internal static void UseDataAccess(this IApplicationBuilder app)
    {
        PersistanceConfiguration.Configure();
    }
}
