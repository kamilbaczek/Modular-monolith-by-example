namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.DataAccess;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddMongo(connectionString);
        services.AddScoped<INotificationsContext, NotificationsContext>();

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
    }
}
