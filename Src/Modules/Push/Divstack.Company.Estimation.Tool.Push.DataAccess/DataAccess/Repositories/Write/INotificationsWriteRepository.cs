namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Write;

using Entities;

public interface INotificationsWriteRepository
{
    Task UpdateAsync(Notification notification, CancellationToken cancellationToken = default);
    Task BulkUpdateAsync(IReadOnlyCollection<Notification> notifications, CancellationToken cancellationToken = default);
    Task AddAsync(Notification notification, CancellationToken cancellationToken = default);
    Task BulkAddAsync(IReadOnlyCollection<Notification> notifications, CancellationToken cancellationToken = default);
}
