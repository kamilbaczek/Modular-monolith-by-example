using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
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
            BsonClassMap.RegisterClassMap<Valuation>(classMap =>
            {
                classMap.SetIgnoreExtraElements(true);
                classMap.MapIdProperty(valuation => valuation.Id).SetElementName("ValuationId");
                classMap.MapProperty("RequestedDate").SetIsRequired(true);
                classMap.MapProperty("InquiryId").SetIsRequired(true);
                classMap.MapProperty("Deadline").SetIsRequired(true);
                classMap.MapProperty("CompletedDate");
                classMap.MapProperty("CompletedBy");
                classMap.MapProperty("Proposals");
                classMap.MapProperty("History");
            });
            BsonClassMap.RegisterClassMap<Proposal>(classMap =>
            {
                classMap.MapProperty("Id").SetElementName("ProposalId").SetIsRequired(true);
                classMap.MapProperty("SuggestedBy").SetIsRequired(true);
                classMap.MapProperty("Suggested").SetIsRequired(true);
                classMap.MapProperty("Decision").SetIsRequired(true);
                classMap.MapProperty("Price").SetIsRequired(true);
                classMap.MapProperty("Description").SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<Money>(classMap =>
            {
                classMap.MapProperty(money => money.Value).SetIsRequired(true);
                classMap.MapProperty(money => money.Currency).SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<EmployeeId>(classMap =>
            {
                classMap.MapProperty(employeeId => employeeId.Value)
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<ProposalDescription>(classMap =>
            {
                classMap.MapProperty("Message").SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<ProposalDecision>(classMap =>
            {
                classMap.MapProperty("Date").SetIsRequired(false);
                classMap.MapProperty("Code").SetIsRequired(true);

            });
            BsonClassMap.RegisterClassMap<Deadline>(classMap =>
            {
                classMap.MapProperty("Date").SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<HistoricalEntry>(cm =>
            {
                cm.MapProperty("Id").SetElementName("HistoricalEntryId");
                cm.MapProperty("Status");
                cm.MapProperty("ChangeDate");
            });
            BsonClassMap.RegisterClassMap<ValuationStatus>(cm =>
            {
                cm.MapProperty("Value");
            });
            BsonClassMap.RegisterClassMap<InquiryId>(classMap =>
            {
                classMap.MapProperty("Value")
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<HistoricalEntryId>(classMap =>
            {
                classMap.MapProperty("Value")
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<ValuationId>(cm =>
            {
                cm.MapProperty("Value")
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<ProposalId>(cm =>
            {
                cm.MapProperty("Value")
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
        } 
    }
}