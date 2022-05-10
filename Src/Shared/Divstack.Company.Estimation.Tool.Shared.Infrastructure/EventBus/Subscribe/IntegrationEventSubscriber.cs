namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe;

using Configuration;
using EventTypes;
using Extensions;
using global::Azure.Messaging.ServiceBus;
using Logger;
using Microsoft.Extensions.Hosting;

public abstract class IntegrationEventSubscriber<TEvent> : IHostedService where TEvent : class
{
    private readonly IEnumerable<IIntegrationEventHandler<TEvent>> _eventHandlers;
    private readonly ServiceBusProcessor _serviceBusProcessor;
    private readonly ISubscriberLogger _logger;

    private static readonly EventType EventType = EventType.From<TEvent>();
    private readonly ServiceBusProcessorOptions _serviceBusProcessorOptions = new()
    {
        AutoCompleteMessages = false
    };

    protected IntegrationEventSubscriber(IServiceProvider serviceProvider,
        ITopicConfiguration topicConfiguration)
    {
        _logger = serviceProvider.GetRequiredService<ISubscriberLogger>();
        _eventHandlers = serviceProvider.GetServices<IIntegrationEventHandler<TEvent>>();

        var eventBusConfiguration = serviceProvider.GetRequiredService<IEventBusConfiguration>();
        var client = new ServiceBusClient(eventBusConfiguration.ConnectionString);

        _serviceBusProcessor = CreateProcessor(topicConfiguration, client, _serviceBusProcessorOptions);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _serviceBusProcessor.StartProcessingAsync(cancellationToken);
    }
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _serviceBusProcessor.StopProcessingAsync(cancellationToken);
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        var message = args.Message;
        var receivedMessageEventType = EventType.FromReceivedMessage(message);

        _logger.LogProcessing(message, receivedMessageEventType);

        if (EventType == receivedMessageEventType)
        {
            var @event = await message.DeserializeAsync<TEvent>();
            foreach (var handler in _eventHandlers)
                await handler.Handle(@event);
        }

        await args.CompleteMessageAsync(args.Message);
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception);
        return Task.CompletedTask;
    }

    private ServiceBusProcessor CreateProcessor(ITopicConfiguration topicConfiguration, ServiceBusClient client, ServiceBusProcessorOptions options, CancellationToken cancellationToken = default)
    {
        var serviceBusProcessor = client.CreateProcessor(topicConfiguration.TopicName, topicConfiguration.SubscriptionName, options);
        serviceBusProcessor.ProcessMessageAsync += MessageHandler;
        serviceBusProcessor.ProcessErrorAsync += ErrorHandler;

        return serviceBusProcessor;
    }
}
