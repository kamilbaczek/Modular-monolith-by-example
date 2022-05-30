namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish;

using DDD.BuildingBlocks;
using Extensions;
using global::Azure.Messaging.ServiceBus;

internal sealed class IntegrationEventMessage : ServiceBusMessage
{
    private const string EventType = "EventType";
    private static readonly string _applicationJson = "application/json";

    private IntegrationEventMessage(IntegrationEvent @event) : base(@event.ToString())
    {
        ContentType = _applicationJson;
        ApplicationProperties[EventType] = @event.GetTypeName();
    }

    internal static IntegrationEventMessage Create(IntegrationEvent @event)
    {
        return new IntegrationEventMessage(@event);
    }
}
