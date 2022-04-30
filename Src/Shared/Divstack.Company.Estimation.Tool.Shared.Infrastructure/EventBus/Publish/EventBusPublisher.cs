namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Configuration;
using DDD.BuildingBlocks;
using Exceptions;
using global::Azure.Messaging.ServiceBus;

internal sealed class EventBusPublisher : IEventBusPublisher
{
    private readonly IEventBusConfiguration _eventBusConfiguration;
    private const string EventType = "EventType";
    private static string _applicationJson = "application/json";

    public EventBusPublisher(
        IEventBusConfiguration eventBusConfiguration)
    {
        _eventBusConfiguration = eventBusConfiguration;
    }

    public async Task PublishAsync(string topic, IReadOnlyCollection<IntegrationEvent> integrationEvents,
        CancellationToken cancellationToken = default)
    {
        var client = new ServiceBusClient(_eventBusConfiguration.ConnectionString);
        var sender = client.CreateSender(topic);
        var messageBatch = await sender.CreateMessageBatchAsync(cancellationToken);
        foreach (var @event in integrationEvents)
        {
            CreateMessage(@event, messageBatch);
        }
        try
        {
            await sender.SendMessagesAsync(messageBatch, cancellationToken);
        }
        finally
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }
    }
    private static void CreateMessage(IntegrationEvent @event, ServiceBusMessageBatch messageBatch)
    {
        var eventAsJson = @event.ToString();
        var message = new ServiceBusMessage(eventAsJson)
        {
            ContentType = _applicationJson,
            ApplicationProperties =
            {
                [EventType] = @event.GetType().Name
            }
        };
        if (!messageBatch.TryAddMessage(message))
        {
            throw new MessageToLargeException();
        }
    }
}
