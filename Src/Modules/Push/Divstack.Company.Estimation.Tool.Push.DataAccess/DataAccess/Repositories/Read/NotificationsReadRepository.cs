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
    public async Task<IReadOnlyCollection<Notification>> GetAllAsync()
    {
        var notifications = await _notificationsContext
            .Notifications
            .Find(Builders<Notification>.Filter.Empty)
            .SortByDescending(notification => notification.EventDate)
            .ToListAsync();

        return notifications;
    }
    public async Task<Notification?> GetOrDefaultAsync(Guid notificationId)
    {
        return await _notificationsContext.Notifications
            .Find(notification => notification.Id == notificationId)
            .SingleOrDefaultAsync();
    }
}
