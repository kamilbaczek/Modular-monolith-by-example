namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Configuration;
using EventTypes;
using Extensions;
using global::Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public abstract class IntegrationEventSubscriber<TEvent> : IHostedService where TEvent : class
{
    private readonly IEnumerable<IIntegrationEventHandler<TEvent>> _eventHandlers;
    private readonly ServiceBusProcessor _serviceBusProcessor;

    private static readonly EventType EventType = EventType.From<TEvent>();

    protected IntegrationEventSubscriber(IServiceProvider serviceProvider,
        ITopicConfiguration topicConfiguration)
    {
        var eventBusConfiguration = serviceProvider.GetRequiredService<IEventBusConfiguration>();
        _eventHandlers = serviceProvider.GetServices<IIntegrationEventHandler<TEvent>>();

        var client = new ServiceBusClient(eventBusConfiguration.ConnectionString);

        _serviceBusProcessor = CreateProcessor(topicConfiguration, client);
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

        if (EventType == receivedMessageEventType)
        {
            var @event = await message.DeserializeMessageAsync<TEvent>();
            foreach (var handler in _eventHandlers)
            {
                await handler.Handle(@event);
            }
        }

        await args.CompleteMessageAsync(args.Message);
    }

    private static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        return Task.CompletedTask;
    }

    private ServiceBusProcessor CreateProcessor(ITopicConfiguration topicConfiguration, ServiceBusClient client, CancellationToken cancellationToken = default)
    {
        var serviceBusProcessor = client.CreateProcessor(topicConfiguration.TopicName, topicConfiguration.SubscriptionName, new ServiceBusProcessorOptions());
        serviceBusProcessor.ProcessMessageAsync += MessageHandler;
        serviceBusProcessor.ProcessErrorAsync += ErrorHandler;

        return serviceBusProcessor;
    }
}
