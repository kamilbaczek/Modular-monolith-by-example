namespace Divstack.Company.Estimation.Tool.Push.Valuations.Hubs;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
internal sealed class ValuationsHub : Hub
{
    internal const string HubUrlPattern = "/hubs/valuations";
}
