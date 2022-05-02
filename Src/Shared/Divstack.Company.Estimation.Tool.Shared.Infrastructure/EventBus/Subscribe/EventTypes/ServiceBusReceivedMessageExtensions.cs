namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.EventTypes;

using Exceptions;
using global::Azure.Messaging.ServiceBus;

internal static class ServiceBusReceivedMessageExtensions
{
    private const string EventTypePropertyName = "EventType";

    internal static string GetEventType(this ServiceBusReceivedMessage message)
    {
        var eventType = message.ApplicationProperties[EventTypePropertyName].ToString();
        if (string.IsNullOrEmpty(eventType))
            throw new EventTypeNotDefinedException();

        return eventType;
    }
}
