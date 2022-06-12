namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.EventTypes.Exceptions;

internal sealed class EventTypeNotDefinedException : InvalidOperationException
{
    private new const string Message = "Event has to have 'EventType' property set in metadata";
    public EventTypeNotDefinedException() : base(Message)
    {
    }
}
