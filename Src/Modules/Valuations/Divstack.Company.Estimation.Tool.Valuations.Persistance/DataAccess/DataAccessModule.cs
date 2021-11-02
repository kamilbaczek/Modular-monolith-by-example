using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess
{
    internal static class DataAccessModule
    {
        internal static IServiceCollection AddDataAccess(this IServiceCollection services,
            string connectionString)
        {
            services.AddMongo(connectionString);
            services.AddScoped<IValuationsContext, ValuationsContext>();
            services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
            services.AddScoped<IReadRepository, ValuationReadonlyRepository>();

            return services;
        }

        private static void AddMongo(this IServiceCollection services, string connectionString)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            var mongoClient = new MongoClient(settings);

            services.AddSingleton(mongoClient);
            PersistanceConfiguration.Configure();
        }
    }
}