namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.SignalR;

using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

internal sealed class UserPublicIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        var userPublicId = connection.User?.FindFirst(ClaimTypes.NameIdentifier);

        return userPublicId?.Value;
    }
}
