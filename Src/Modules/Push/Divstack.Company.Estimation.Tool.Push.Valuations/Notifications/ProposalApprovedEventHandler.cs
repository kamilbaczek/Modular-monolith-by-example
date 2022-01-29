namespace Divstack.Company.Estimation.Tool.Push.Valuations.Notifications;

using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalApprovedEventHandler : INotificationHandler<ProposalApproved>
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly IHubContext<ValuationsHub> _valuationsHub;
    public ProposalApprovedEventHandler(IHubContext<ValuationsHub> valuationsHub, INotificationsWriteRepository notificationsWriteRepository)
    {
        _valuationsHub = valuationsHub;
        _notificationsWriteRepository = notificationsWriteRepository;
    }
    public async Task Handle(ProposalApproved @event, CancellationToken cancellationToken)
    {
        var notification = Notification.Create(@event.ValuationId, nameof(ProposalApproved), @event.SuggestedBy);
        await _notificationsWriteRepository.AddAsync(notification, cancellationToken);
        var userId = @event.SuggestedBy.ToString();
        await _valuationsHub.Clients.User(userId).SendAsync(nameof(ProposalApproved), @event, cancellationToken);
    }
}
