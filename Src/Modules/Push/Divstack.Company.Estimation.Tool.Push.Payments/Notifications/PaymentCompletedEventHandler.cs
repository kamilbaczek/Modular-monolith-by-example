namespace Divstack.Company.Estimation.Tool.Push.Payments.Notifications;

using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tool.Payments.IntegrationsEvents.External;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetAllUsers;

internal sealed class PaymentCompletedEventHandler : INotificationHandler<PaymentCompleted>
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly IHubContext<PaymentsHub> _paymentsHub;
    private readonly IUserModule _userModule;
    public PaymentCompletedEventHandler(IHubContext<PaymentsHub> paymentsHub,
        INotificationsWriteRepository notificationsWriteRepository,
        IUserModule userModule)
    {
        _paymentsHub = paymentsHub;
        _notificationsWriteRepository = notificationsWriteRepository;
        _userModule = userModule;
    }

    public async Task Handle(PaymentCompleted @event, CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();
        var userList = await _userModule.ExecuteQueryAsync(query);
        foreach (var userDto in userList.Users)
        {
            var notification = Notification.Create(@event.PaymentId, nameof(PaymentCompleted), userDto.PublicId);
            await _notificationsWriteRepository.AddAsync(notification, cancellationToken);
        }
        await _paymentsHub.Clients.All.SendAsync(nameof(PaymentCompleted), @event, cancellationToken);
    }
}
