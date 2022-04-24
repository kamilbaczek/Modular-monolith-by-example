namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using global::Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public abstract class IntegrationEventSubscriber<TEvent> : IHostedService where TEvent : class
{
    private readonly IMediator _mediator;

    private readonly ServiceBusProcessor _serviceBusProcessor;

    private const string EventType = "EventType";

    protected IntegrationEventSubscriber(IServiceProvider serviceProvider,
        ITopicConfiguration topicConfiguration)
    {
        var topicConfiguration1 = topicConfiguration;

        _mediator = serviceProvider.GetRequiredService<IMediator>();
        var eventBusConfiguration = serviceProvider.GetRequiredService<IEventBusConfiguration>();

        var client = new ServiceBusClient(eventBusConfiguration.ConnectionString);

        _serviceBusProcessor = client.CreateProcessor(topicConfiguration1.TopicName, topicConfiguration1.SubscriptionName, new ServiceBusProcessorOptions());
        _serviceBusProcessor.ProcessMessageAsync += MessageHandler;
        _serviceBusProcessor.ProcessErrorAsync += ErrorHandler;
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
        var eventType = GetEventType(message);

        if (eventType == nameof(TEvent))
        {
            var body = message.Body;
            var @event = await JsonSerializer.DeserializeAsync<TEvent>(body.ToStream());

            await _mediator.Publish(@event);
        }

        await args.CompleteMessageAsync(args.Message);
    }
    private static string GetEventType(ServiceBusReceivedMessage message)
    {
        var eventType = message.ApplicationProperties[EventType].ToString();
        if (string.IsNullOrEmpty(eventType))
            throw new InvalidOperationException("Even has to have 'EventType' property set in metadata");

        return eventType;
    }

    private static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        return Task.CompletedTask;
    }
}
