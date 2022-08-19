namespace Divstack.Company.Estimation.Tool.Push.Payments.Hubs;

using Microsoft.AspNetCore.SignalR;

internal sealed class PaymentsHub : Hub
{
    internal const string HubUrlPattern = "/hubs/payments";
}
