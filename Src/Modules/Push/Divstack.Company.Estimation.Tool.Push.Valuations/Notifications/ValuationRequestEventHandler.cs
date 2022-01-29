namespace Divstack.Company.Estimation.Tool.Push.Valuations.Notifications;

using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Users.Application.Contracts;
using Users.Application.Users.Queries.GetAllUsers;

internal sealed class ValuationRequestEventHandler : INotificationHandler<ValuationRequested>
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly IUserModule _userModule;
    private readonly IHubContext<ValuationsHub> _valuationsHub;
    public ValuationRequestEventHandler(IHubContext<ValuationsHub> valuationsHub,
        INotificationsWriteRepository notificationsWriteRepository,
        IUserModule userModule)
    {
        _valuationsHub = valuationsHub;
        _notificationsWriteRepository = notificationsWriteRepository;
        _userModule = userModule;
    }
    public async Task Handle(ValuationRequested @event, CancellationToken cancellationToken)
    {
        var usersList = await _userModule.ExecuteQueryAsync(new GetAllUsersQuery());
        var notifications = usersList.Users
            .Select(user =>
                Notification.Create(@event.ValuationId,
                    nameof(ValuationRequested),
                    user.PublicId))
            .ToList();
        await _notificationsWriteRepository.BulkAddAsync(notifications, cancellationToken);
        await _valuationsHub.Clients.All.SendAsync(nameof(ValuationRequested), @event, cancellationToken);
    }
}
