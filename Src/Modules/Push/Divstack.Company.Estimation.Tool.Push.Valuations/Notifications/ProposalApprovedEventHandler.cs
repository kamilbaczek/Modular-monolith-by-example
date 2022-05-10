namespace Divstack.Company.Estimation.Tool.Push.Valuations.Notifications;

using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Shared.Infrastructure.EventBus.Subscribe;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalApprovedEventHandler : IIntegrationEventHandler<ProposalApproved>
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly IHubContext<ValuationsHub> _valuationsHub;
    public ProposalApprovedEventHandler(IHubContext<ValuationsHub> valuationsHub, INotificationsWriteRepository notificationsWriteRepository)
    {
        _valuationsHub = valuationsHub;
        _notificationsWriteRepository = notificationsWriteRepository;
    }
    public async ValueTask Handle(ProposalApproved @event, CancellationToken cancellationToken)
    {
        var notification = Notification.Create(@event.ValuationId, nameof(ProposalApproved), @event.SuggestedBy);
        await _notificationsWriteRepository.AddAsync(notification, cancellationToken);
        var userId = @event.SuggestedBy.ToString();
        await _valuationsHub.Clients.User(userId).SendAsync(nameof(ProposalApproved), @event, cancellationToken);
    }
}
