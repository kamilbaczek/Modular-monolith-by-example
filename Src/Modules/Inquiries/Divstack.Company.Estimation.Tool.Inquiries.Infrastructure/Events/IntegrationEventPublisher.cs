namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;

using Azure.Messaging.ServiceBus;
using Mapper;
using Microsoft.Extensions.Configuration;
using Shared.DDD.BuildingBlocks;
using Shared.Infrastructure.EventBus.Configuration;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private const string EventType = "EventType";
    private readonly IEventMapper _eventMapper;
    private readonly IConfiguration _configuration;
    private readonly IEventBusConfiguration _eventBusConfiguration;
    private static string _applicationJson = "application/json";

    public IntegrationEventPublisher(
        IEventMapper eventMapper,
        IConfiguration configuration,
        IEventBusConfiguration eventBusConfiguration)
    {
        _eventMapper = eventMapper;
        _configuration = configuration;
        _eventBusConfiguration = eventBusConfiguration;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper.Map(domainEvents);

        var client = new ServiceBusClient(_eventBusConfiguration.ConnectionString);
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
