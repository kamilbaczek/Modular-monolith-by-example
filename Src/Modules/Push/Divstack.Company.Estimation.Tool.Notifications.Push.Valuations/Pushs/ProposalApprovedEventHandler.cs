namespace Divstack.Company.Estimation.Tool.Push.Valuations.Pushs;

using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalApprovedEventHandler : INotificationHandler<ProposalApproved>
{
    private readonly IHubContext<ValuationsHub> _valuationsHub;
    public ProposalApprovedEventHandler(IHubContext<ValuationsHub> valuationsHub)
    {
        _valuationsHub = valuationsHub;
    }
    public async Task Handle(ProposalApproved notification, CancellationToken cancellationToken)
    {
        await _valuationsHub.Clients.All.SendAsync(nameof(ProposalApproved), notification, cancellationToken: cancellationToken);
    }
}
