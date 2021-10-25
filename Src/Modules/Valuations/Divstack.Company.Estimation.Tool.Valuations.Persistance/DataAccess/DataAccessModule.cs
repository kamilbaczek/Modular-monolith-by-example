using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
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
            
            ConfigureMapping();
            services.AddSingleton(mongoClient);
        }

        private static void ConfigureMapping()
        {
            ConventionRegistry.Register(nameof(ImmutableTypeClassMapConvention), 
                new ConventionPack { new ImmutableTypeClassMapConvention()}, type => true);
            BsonClassMap.RegisterClassMap<Valuation>(cm =>
            {
                cm.SetIgnoreExtraElements(true);
                cm.MapIdProperty(valuation => valuation.Id);
                cm.MapProperty("RequestedDate");
                cm.MapProperty("InquiryId");
                // cm.MapProperty("CompletedDate");
                cm.MapProperty("Deadline");
                // cm.MapProperty("Proposals");
                cm.MapProperty("History");
            });
            // BsonClassMap.RegisterClassMap<Proposal>(cm =>
            // {
            //     cm.MapProperty("Id");
            //     cm.MapProperty("Description");
            // });
            BsonClassMap.RegisterClassMap<Deadline>(cm =>
            {
                cm.MapProperty("Date");
            });
            BsonClassMap.RegisterClassMap<HistoricalEntry>(cm =>
            {
                cm.MapProperty("Id");
                cm.MapProperty("Status");
                cm.MapProperty("ChangeDate");
            });
            BsonClassMap.RegisterClassMap<ValuationStatus>(cm =>
            {
                cm.MapProperty("Value");
            });
            BsonClassMap.RegisterClassMap<HistoricalEntryId>(cm =>
            {
                cm.MapProperty("Value").SetSerializer(new GuidSerializer(BsonType.String));
            });
            BsonClassMap.RegisterClassMap<InquiryId>(cm =>
            {
                cm.MapProperty("Value").SetSerializer(new GuidSerializer(BsonType.String));;
            });
            BsonClassMap.RegisterClassMap<ValuationId>(cm =>
            {
                cm.MapProperty("Value").SetSerializer(new GuidSerializer(BsonType.String));;
            });
        }
    }
}