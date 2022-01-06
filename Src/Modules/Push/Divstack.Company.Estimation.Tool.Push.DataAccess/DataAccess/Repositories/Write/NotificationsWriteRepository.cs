namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Write;

using Context;
using Entities;
using MongoDB.Driver;

internal sealed class NotificationsWriteRepository : INotificationsWriteRepository
{
    private readonly INotificationsContext _notificationsContext;
    public NotificationsWriteRepository(INotificationsContext notificationsContext)
    {
        _notificationsContext = notificationsContext;
    }

    public async Task UpdateAsync(Notification notificationToUpdate)
    {
        await _notificationsContext.Notifications
            .ReplaceOneAsync(notification => notification.Id == notificationToUpdate.Id, notificationToUpdate);
    }

    public async Task AddAsync(Notification notification)
    {
        await _notificationsContext.Notifications.InsertOneAsync(notification);
    }
}
