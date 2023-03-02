namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.DataAccess;

using Domain.Priorities.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

internal static class DataAccessModule
{
    internal static void AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddMongo(connectionString);
        services.AddRepositories();
        services.AddScoped<IPrioritiesContext, PrioritiesContext>();
    }

    private static void AddMongo(this IServiceCollection services, string connectionString)
    {
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        var mongoClient = new MongoClient(settings);

        services.AddSingleton(mongoClient);
    }
}
