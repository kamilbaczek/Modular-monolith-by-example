namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Read;

using Context;
using Entities;
using MongoDB.Driver;

internal sealed class NotificationsReadRepository : INotificationsReadRepository
{
    private readonly INotificationsContext _notificationsContext;
    public NotificationsReadRepository(INotificationsContext notificationsContext)
    {
        _notificationsContext = notificationsContext;
    }

    public async Task<IReadOnlyCollection<Notification>> GetAllAsync(Guid receiverId, CancellationToken cancellationToken = default)
    {
        var notifications = await _notificationsContext
            .Notifications
            .Find(notification => notification.ReceiverId == receiverId)
            .SortByDescending(notification => notification.EventDate)
            .ToListAsync(cancellationToken);

        return notifications;
    }
    public async Task<Notification?> GetOrDefaultAsync(Guid notificationId, CancellationToken cancellationToken = default)
    {
        return await _notificationsContext.Notifications
            .Find(notification => notification.Id == notificationId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}
