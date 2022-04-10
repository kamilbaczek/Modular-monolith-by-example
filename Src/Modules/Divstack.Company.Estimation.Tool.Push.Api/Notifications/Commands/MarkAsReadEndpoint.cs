namespace Divstack.Company.Estimation.Tool.Push.Api.Notifications.Commands;

using Common.CurrentUser;
using DataAccess.DataAccess.Repositories.Read;
using DataAccess.DataAccess.Repositories.Write;

internal sealed class MarkAsReadEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithoutResult
{
    private readonly INotificationsWriteRepository _notificationsWriteRepository;
    private readonly INotificationsReadRepository _notificationsReadRepository;

    private readonly Guid _currentUserId;
    public MarkAsReadEndpoint(ICurrentUserService currentUserService,
        INotificationsWriteRepository notificationsWriteRepository,
        INotificationsReadRepository notificationsReadRepository)
    {
        _currentUserId = currentUserService.GetPublicUserId();
        _notificationsWriteRepository = notificationsWriteRepository;
        _notificationsReadRepository = notificationsReadRepository;
    }

    [HttpPatch]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route($"{NotificationsRouting.Url}/{{id}}/mark-as-read")]
    [SwaggerOperation(
        Summary = nameof(MarkAsReadEndpoint),
        Tags = new[]
        {
            nameof(PushApiModule)
        })
    ]
    public override async Task<IActionResult> HandleAsync(Guid id, CancellationToken cancellationToken = new())
    {
        var notification = await _notificationsReadRepository.GetOrDefaultAsync(id, _currentUserId, cancellationToken);
        if (notification is null)
            return NotFound();
        notification.MarkAsRead();
        await _notificationsWriteRepository.UpdateAsync(notification, cancellationToken);

        return Ok();
    }
}
