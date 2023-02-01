using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess;

using Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repositories.Read;
using Repositories.Write;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName)!;
        services.AddMongo(connectionString);
        services.AddScoped<INotificationsContext, NotificationsContext>();
        services.AddScoped<INotificationsReadRepository, NotificationsReadRepository>();
        services.AddScoped<INotificationsWriteRepository, NotificationsWriteRepository>();

        return services;
    }

    private static void AddMongo(this IServiceCollection services, string connectionString)
    {
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        var mongoClient = new MongoClient(settings);

        services.AddSingleton(mongoClient);
    }
}
