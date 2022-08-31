namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

using System.Reflection;
using Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using NServiceBus;

internal static class EventBusModule
{
    private const string AuditQueue = "audit";

    internal static void UseEvents(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseNServiceBus(context =>
        {
            var name = GetName();

            var endpointConfiguration = new EndpointConfiguration(name);
            var eventBusConfiguration = new EventBusConfiguration(context.Configuration);

            SetupTransport(endpointConfiguration, eventBusConfiguration);
            ConfigurePersistance(endpointConfiguration, eventBusConfiguration);

            endpointConfiguration.EnableOutbox();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo(AuditQueue);

            return endpointConfiguration;
        });
    }

    private static void ConfigurePersistance(EndpointConfiguration endpointConfiguration, IEventBusConfiguration configuration)
    {
        var persistence = endpointConfiguration.UsePersistence<MongoPersistence>();
        var client = new MongoClient(configuration.StorageConnectionString);
        persistence.MongoClient(client);
        persistence.DatabaseName(configuration.DatabaseName);
    }

    private static void SetupTransport(EndpointConfiguration endpointConfiguration, IEventBusConfiguration configuration)
    {
        var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
        transport.ConnectionString(configuration.ConnectionString);
    }

    private static string? GetName() => Assembly.GetEntryAssembly()?.GetName().Name;
}
