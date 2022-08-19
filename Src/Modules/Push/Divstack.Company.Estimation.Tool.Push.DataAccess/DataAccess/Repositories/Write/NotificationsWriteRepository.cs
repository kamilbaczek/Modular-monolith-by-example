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

    public async Task UpdateAsync(Notification notificationToUpdate, CancellationToken cancellationToken = default)
    {
        await _notificationsContext.Notifications
            .ReplaceOneAsync(notification => notification.Id == notificationToUpdate.Id, notificationToUpdate, cancellationToken: cancellationToken);
    }
    public async Task BulkUpdateAsync(IReadOnlyCollection<Notification> notifications, CancellationToken cancellationToken = default)
    {
        foreach (var notificationToUpdate in notifications)
        {
            await _notificationsContext.Notifications.ReplaceOneAsync(notification => notification.Id == notificationToUpdate.Id, notificationToUpdate, cancellationToken: cancellationToken);
        }
    }

    public async Task AddAsync(Notification notification, CancellationToken cancellationToken = default)
    {
        await _notificationsContext.Notifications.InsertOneAsync(notification, cancellationToken: cancellationToken);
    }

    public async Task BulkAddAsync(IReadOnlyCollection<Notification> notifications, CancellationToken cancellationToken = default)
    {
        await _notificationsContext.Notifications.InsertManyAsync(notifications, cancellationToken: cancellationToken);
    }
}
