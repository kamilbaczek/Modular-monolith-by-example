namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.EventTypes;

using global::Azure.Messaging.ServiceBus;

internal record EventType(string Value)
{
    internal static EventType From<TEvent>()
    {
        return new EventType(typeof(TEvent).Name);
    }

    internal static EventType FromReceivedMessage(ServiceBusReceivedMessage message)
    {
        var eventType = message.GetEventType();
        return new EventType(eventType);
    }
}
