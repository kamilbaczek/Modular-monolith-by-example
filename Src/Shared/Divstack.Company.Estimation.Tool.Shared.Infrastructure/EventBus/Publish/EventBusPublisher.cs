namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish;

using Configuration;
using DDD.BuildingBlocks;
using Exceptions;
using global::Azure.Messaging.ServiceBus;

internal sealed class EventBusPublisher : IEventBusPublisher
{
    private readonly ServiceBusClient _serviceBusClient;

    public EventBusPublisher(
        IEventBusConfiguration eventBusConfiguration)
    {
        _serviceBusClient = new ServiceBusClient(eventBusConfiguration.ConnectionString);
    }

    public async Task PublishAsync(string topic, IReadOnlyCollection<IntegrationEvent> integrationEvents,
        CancellationToken cancellationToken = default)
    {
        var sender = _serviceBusClient.CreateSender(topic);
        var messageBatch = await sender.CreateMessageBatchAsync(cancellationToken);

        foreach (var @event in integrationEvents)
            CreateMessage(@event, messageBatch);

        await sender.SendMessagesAsync(messageBatch, cancellationToken);
    }
    private static void CreateMessage(IntegrationEvent @event, ServiceBusMessageBatch messageBatch)
    {
        var message = IntegrationEventMessage.Create(@event);
        if (!messageBatch.TryAddMessage(message))
        {
            throw new MessageToLargeException();
        }
    }
}
