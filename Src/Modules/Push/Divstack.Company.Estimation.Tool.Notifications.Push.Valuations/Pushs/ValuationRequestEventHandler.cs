namespace Divstack.Company.Estimation.Tool.Push.Valuations.Pushs;

using Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ValuationRequestEventHandler : INotificationHandler<ValuationRequested>
{
    private readonly IHubContext<ValuationsHub> _valuationsHub;
    public ValuationRequestEventHandler(IHubContext<ValuationsHub> valuationsHub)
    {
        _valuationsHub = valuationsHub;
    }
    public async Task Handle(ValuationRequested notification, CancellationToken cancellationToken)
    {
        await _valuationsHub.Clients.All.SendAsync(nameof(ValuationRequested), notification, cancellationToken: cancellationToken);
    }
}
