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
        
            SetupTransport(endpointConfiguration, eventBusConfiguration, context.HostingEnvironment);
            ConfigurePersistance(endpointConfiguration, eventBusConfiguration);
            
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo(AuditQueue);
        
            return endpointConfiguration;
        });
    }

    private static void ConfigurePersistance(EndpointConfiguration endpointConfiguration, IEventBusConfiguration configuration)
    {
        var persistence = endpointConfiguration
            .UsePersistence<MongoPersistence>()
            .UseTransactions(false);
        
        var client = new MongoClient(configuration.StorageConnectionString);
        persistence.MongoClient(client);
        persistence.DatabaseName(configuration.DatabaseName);
    }

    private static void SetupTransport(EndpointConfiguration endpointConfiguration, IEventBusConfiguration configuration, IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment.IsDevelopment())
        {
            endpointConfiguration.UseTransport<RabbitMQTransport>()
                .ConnectionString(configuration.ConnectionString)
                .UseConventionalRoutingTopology(QueueType.Classic);
            
            return;
        }
        
        var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
        transport.ConnectionString(configuration.ConnectionString);
    }

    private static string? GetName() => Assembly.GetEntryAssembly()?.GetName().Name;
}
