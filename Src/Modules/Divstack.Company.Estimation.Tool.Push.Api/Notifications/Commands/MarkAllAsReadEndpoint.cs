namespace Divstack.Company.Estimation.Tool.Push.Api.Notifications.Commands;

using Common.CurrentUser;
using DataAccess.DataAccess.Repositories.Read;
using DataAccess.DataAccess.Repositories.Write;

internal sealed class MarkAllAsReadEndpoint : EndpointBaseAsync.WithoutRequest.WithoutResult
{
    private readonly Guid _currentUserId;
    private readonly INotificationsReadRepository _notificationsReadRepository;
    private readonly INotificationsWriteRepository _notificationsWriteRepository;

    public MarkAllAsReadEndpoint(ICurrentUserService currentUserService,
        INotificationsWriteRepository notificationsWriteRepository,
        INotificationsReadRepository notificationsReadRepository)
    {
        _currentUserId = currentUserService.GetPublicUserId();
        _notificationsWriteRepository = notificationsWriteRepository;
        _notificationsReadRepository = notificationsReadRepository;
    }

    [HttpPatch]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route($"{NotificationsRouting.Url}/mark-all-as-read")]
    [SwaggerOperation(
        Summary = nameof(MarkAllAsReadEndpoint),
        Tags = new[]
        {
            nameof(PushApiModule)
        })
    ]
    public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new())
    {
        var notReadNotifications = await _notificationsReadRepository.GetNotReadAsync(_currentUserId, cancellationToken);

        foreach (var notification in notReadNotifications)
            notification.MarkAsRead();

        await _notificationsWriteRepository.BulkUpdateAsync(notReadNotifications, cancellationToken);

        return Ok();
    }
}
