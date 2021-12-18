namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.Application;

using DataAccess;
using Domain;
using MediatR;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ValuationRequestEventHandler : INotificationHandler<ValuationRequested>
{
    private readonly INotificationsContext _notificationContext;
    public ValuationRequestEventHandler(INotificationsContext notificationContext)
    {
        _notificationContext = notificationContext;
    }
    public async Task Handle(ValuationRequested @event, CancellationToken cancellationToken)
    {
        var notification = Notification.Create(@event.ValuationId, "Valuation", "Requested");
        await _notificationContext.Notifications.InsertOneAsync(notification, null, cancellationToken);
    }
}
