namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing.Storage;

using Configuration;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

internal static class BackgroundJobsStorageExtensions
{
    private const string CollectionPrefix = "hangfire";

    private static MongoStorageOptions MongoStorageOptions => new()
    {
        MigrationOptions = new MongoMigrationOptions
        {
            MigrationStrategy = new MigrateMongoMigrationStrategy(), BackupStrategy = new CollectionMongoBackupStrategy()
        },
        Prefix = CollectionPrefix,
        CheckConnection = true
    };

    internal static IGlobalConfiguration UseMongoAsStorage(this IGlobalConfiguration hangfireConfiguration, IConfiguration configuration)
    {
        var backgroundProcessingConfiguration = new BackgroundProcessingConfiguration(configuration);
        var mongoUrlBuilder = new MongoUrlBuilder(backgroundProcessingConfiguration.StorageConnectionString);
        var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

        hangfireConfiguration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName,
                MongoStorageOptions);

        return hangfireConfiguration;
    }
}
