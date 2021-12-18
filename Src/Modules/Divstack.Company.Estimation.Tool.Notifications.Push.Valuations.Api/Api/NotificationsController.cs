namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.Api;

using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

internal sealed class NotificationsController : BaseController
{
    private readonly INotificationsContext _notificationsContext;
    public NotificationsController(INotificationsContext notificationsContext)
    {
        _notificationsContext = notificationsContext;
    }

    [HttpGet]
    public async Task<ActionResult<Notification>> GetAll()
    {
        var notifications = await _notificationsContext
            .Notifications
            .Find(Builders<Notification>.Filter.Empty)
            .ToListAsync();

        return Ok(notifications);
    }
}
