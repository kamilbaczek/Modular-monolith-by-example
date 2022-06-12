namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

using System.Reflection;
using Configuration;
using Microsoft.Extensions.Hosting;
using NServiceBus;

internal static class EventBusModule
{
    private const string AuditQueue = "audit";

    internal static void UseEvents(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseNServiceBus(context =>
        {
            var name = Assembly.GetEntryAssembly()?.GetName().Name;
            var endpointConfiguration = new EndpointConfiguration(name);

            SetupTransport(endpointConfiguration, context);

            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo(AuditQueue);

            return endpointConfiguration;
        });
    }

    private static void SetupTransport(EndpointConfiguration endpointConfiguration, HostBuilderContext context)
    {
        var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
        var configuration = new EventBusConfiguration(context.Configuration);
        transport.ConnectionString(configuration.ConnectionString);
    }
}
