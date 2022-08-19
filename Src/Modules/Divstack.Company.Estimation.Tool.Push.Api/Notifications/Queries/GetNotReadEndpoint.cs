namespace Divstack.Company.Estimation.Tool.Push.Api.Notifications.Queries;

using Common.CurrentUser;
using DataAccess.DataAccess.Repositories.Read;
using DataAccess.Entities;

internal sealed class GetNotReadEndpoint : EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<IReadOnlyCollection<Notification>>>
{
    private readonly Guid _currentUserId;
    private readonly INotificationsReadRepository _notificationsReadRepository;

    public GetNotReadEndpoint(ICurrentUserService currentUserService, INotificationsReadRepository notificationsReadRepository)
    {
        _currentUserId = currentUserService.GetPublicUserId();
        _notificationsReadRepository = notificationsReadRepository;
    }

    [HttpGet]
    [Route(NotificationsRouting.Url)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(GetNotReadEndpoint),
        Tags = new[]
        {
            nameof(PushApiModule)
        })
    ]
    public override async Task<ActionResult<IReadOnlyCollection<Notification>>> HandleAsync(CancellationToken cancellationToken = new())
    {
        var notifications = await _notificationsReadRepository.GetNotReadAsync(_currentUserId, cancellationToken);

        return Ok(notifications);
    }
}
