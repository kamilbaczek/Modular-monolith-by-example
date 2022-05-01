namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish;

using DDD.BuildingBlocks;
using Extensions;
using global::Azure.Messaging.ServiceBus;

internal sealed class IntegrationEventMessage : ServiceBusMessage
{
    private const string EventType = "EventType";
    private static string _applicationJson = "application/json";

    private IntegrationEventMessage(string @event) : base(@event)
    {
    }

    private IntegrationEventMessage(IntegrationEvent @event)
    {
        ContentType = _applicationJson;
        ApplicationProperties[EventType] = @event.GetTypeName();
    }

    internal static IntegrationEventMessage Create(IntegrationEvent @event)
    {
        return new IntegrationEventMessage(@event);
    }
}
