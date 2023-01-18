namespace Divstack.Company.Estimation.Tool.Push.Valuations.Notifications;

using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Hubs;
using Microsoft.AspNetCore.SignalR;
using NServiceBus;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalApprovedEventHandler : IHandleMessages<ProposalApproved>
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly IHubContext<ValuationsHub> _valuationsHub;
    
    public ProposalApprovedEventHandler(IHubContext<ValuationsHub> valuationsHub, INotificationsWriteRepository notificationsWriteRepository)
    {
        _valuationsHub = valuationsHub;
        _notificationsWriteRepository = notificationsWriteRepository;
    }

    public async Task Handle(ProposalApproved proposalApprovedEvent, IMessageHandlerContext context)
    {
        var notification = Notification.Create(proposalApprovedEvent.ValuationId, nameof(ProposalApproved), proposalApprovedEvent.SuggestedBy);
        await _notificationsWriteRepository.AddAsync(notification, context.CancellationToken);
        var employeeId = proposalApprovedEvent.SuggestedBy.ToString();
        await _valuationsHub.Clients.User(employeeId).SendAsync(nameof(ProposalApproved), proposalApprovedEvent, context.CancellationToken);
    }
}
