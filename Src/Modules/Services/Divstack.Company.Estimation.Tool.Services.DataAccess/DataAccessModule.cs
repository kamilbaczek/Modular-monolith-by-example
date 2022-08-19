using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Services.Api")]

namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using Core;
using HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repositories;
using Seeder;

internal static class DataAccessModule
{
    private const string ServicesConnectionString = "Services";
    private const string Repository = "Repository";

    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ServicesConnectionString);

        services.AddCore();
        services.RegisterRepositories();
        services.AddDataAccessHealthChecks(connectionString);
        services.AddMongo(connectionString);
        services.AddScoped<IServicesContext, ServicesContext>();
        services.AddSeeders();

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ServicesRepository>()
            .AddClasses(filter => filter.Where(@class => @class.Name.EndsWith(Repository, StringComparison.InvariantCultureIgnoreCase)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }

    private static void AddMongo(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IServicesContext, ServicesContext>();
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        var mongoClient = new MongoClient(settings);

        services.AddSingleton(mongoClient);
    }
}
