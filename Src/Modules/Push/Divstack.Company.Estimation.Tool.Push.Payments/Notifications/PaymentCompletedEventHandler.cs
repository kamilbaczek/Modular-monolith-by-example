namespace Divstack.Company.Estimation.Tool.Push.Payments.Notifications;

using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tool.Payments.IntegrationsEvents.External;

internal sealed class PaymentCompletedEventHandler : INotificationHandler<PaymentCompleted>
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly IHubContext<PaymentsHub> _paymentsHub;
    public PaymentCompletedEventHandler(IHubContext<PaymentsHub> paymentsHub,
        INotificationsWriteRepository notificationsWriteRepository)
    {
        _paymentsHub = paymentsHub;
        _notificationsWriteRepository = notificationsWriteRepository;
    }

    public async Task Handle(PaymentCompleted @event, CancellationToken cancellationToken)
    {
        var notification = Notification.Create(@event.PaymentId, nameof(PaymentCompleted));
        await _notificationsWriteRepository.AddAsync(notification);
        await _paymentsHub.Clients.All.SendAsync(nameof(PaymentCompleted), @event, cancellationToken);
    }
}
