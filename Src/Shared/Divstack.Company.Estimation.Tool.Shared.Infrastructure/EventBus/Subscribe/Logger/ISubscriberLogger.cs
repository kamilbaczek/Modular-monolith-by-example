namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.Logger;

using EventTypes;
using global::Azure.Messaging.ServiceBus;

internal interface ISubscriberLogger
{
    void LogProcessingStarted(ServiceBusReceivedMessage message, EventType receivedMessageEventType);
    void LogProcessingCompleted(ServiceBusReceivedMessage message, EventType receivedMessageEventType);

    void LogError(Exception exception);
}
