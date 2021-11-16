namespace Divstack.Company.Estimation.Tool.Payments.Persistance.DataAccess;

using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddMongo(connectionString);
        services.AddScoped<IPaymentsContext, PaymentsContext>();

        return services;
    }

    private static void AddMongo(this IServiceCollection services, string connectionString)
    {
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        var mongoClient = new MongoClient(settings);

        services.AddSingleton(mongoClient);
    }
}
