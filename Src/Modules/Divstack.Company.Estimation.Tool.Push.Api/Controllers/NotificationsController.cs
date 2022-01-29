namespace Divstack.Company.Estimation.Tool.Push.Api.Controllers;

using Common.CurrentUser;
using DataAccess.DataAccess.Repositories.Read;
using DataAccess.DataAccess.Repositories.Write;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class NotificationsController : BaseController
{
    private readonly ICurrentUserService _currentUserService;
    private readonly INotificationsReadRepository _notificationsReadRepository;
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    public NotificationsController(INotificationsReadRepository notificationsReadRepository,
        INotificationsWriteRepository notificationsWriteRepository,
        ICurrentUserService currentUserService)
    {
        _notificationsReadRepository = notificationsReadRepository;
        _notificationsWriteRepository = notificationsWriteRepository;
        _currentUserService = currentUserService;
    }

    [HttpGet]
    public async Task<ActionResult<Notification>> GetAll()
    {
        var currentUserId = _currentUserService.GetPublicUserId();
        var notifications = await _notificationsReadRepository.GetAllAsync(currentUserId);

        return Ok(notifications);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("{id}/markAsRead")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> MarkAsRead(Guid id)
    {
        var notification = await _notificationsReadRepository.GetOrDefaultAsync(id);
        if (notification is null)
            return NotFound();
        notification.MarkAsRead();
        await _notificationsWriteRepository.UpdateAsync(notification);

        return Ok();
    }
}
