using Microsoft.AspNetCore.Authorization;

namespace Divstack.Company.Estimation.Tool.Push.Valuations.Hubs;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
internal sealed class ValuationsHub : Hub
{
    internal const string HubUrlPattern = "/hubs/valuations";

    public override async Task OnConnectedAsync()
    {
        var userPublicId = Context?.User?.FindFirst(ClaimTypes.NameIdentifier);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await base.OnDisconnectedAsync(exception);
    }
}
