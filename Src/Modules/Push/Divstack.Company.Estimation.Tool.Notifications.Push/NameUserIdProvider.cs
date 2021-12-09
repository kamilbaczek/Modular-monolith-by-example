namespace Divstack.Company.Estimation.Tool.Notifications.Push;

using Microsoft.AspNetCore.SignalR;

public class NameUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User?.Identity?.Name;
    }
}
