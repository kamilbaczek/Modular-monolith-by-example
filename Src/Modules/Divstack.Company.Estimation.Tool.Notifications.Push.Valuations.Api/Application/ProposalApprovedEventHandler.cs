namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.Application;

using DataAccess;
using Domain;
using MediatR;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalApprovedEventHandler : INotificationHandler<ProposalApproved>
{
    private readonly INotificationsContext _notificationContext;
    public ProposalApprovedEventHandler(INotificationsContext notificationContext)
    {
        _notificationContext = notificationContext;
    }
    public async Task Handle(ProposalApproved @event, CancellationToken cancellationToken)
    {
        var notification = Notification.Create(@event.ValuationId, "Valuation", "Approved");
        await _notificationContext.Notifications.InsertOneAsync(notification, null, cancellationToken);
    }
}
