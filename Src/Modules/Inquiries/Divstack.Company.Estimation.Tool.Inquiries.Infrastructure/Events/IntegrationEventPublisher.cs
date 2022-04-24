namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;

using Azure.Messaging.ServiceBus;
using Mapper;
using Microsoft.Extensions.Configuration;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private const string EventType = "EventType";
    private readonly IEventMapper _eventMapper;
    private readonly IConfiguration _configuration;
    private static string _applicationJson = "application/json";

    public IntegrationEventPublisher(
        IEventMapper eventMapper,
        IConfiguration configuration)
    {
        _eventMapper = eventMapper;
        _configuration = configuration;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents);

        var client = new ServiceBusClient("Endpoint=sb://estimation-tool.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=FWPn0bk7yx0XKwPMznUacNhfnIj7cE3yKnsLZw6CPOA=");
        var sender = client.CreateSender("inquiries");
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
            throw new Exception($"The message  is too large to fit in the batch.");
        }
    }
}
