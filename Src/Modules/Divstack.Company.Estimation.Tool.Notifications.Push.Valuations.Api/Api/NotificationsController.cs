namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.Api;

using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http;
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
            .SortByDescending(notification => notification.EventDate)
            .ToListAsync();

        return Ok(notifications);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("{id}/markAsRead")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> MarkAsRead(Guid id)
    {
        var notification = await _notificationsContext
            .Notifications
            .Find(notification => notification.Id == id)
            .SingleOrDefaultAsync();
        if (notification is null)
            return NotFound();
        notification.MarkAsRead();

        await _notificationsContext.Notifications.ReplaceOneAsync(notification => notification.Id == id, notification);
        return Ok();
    }
}
