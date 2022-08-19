namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Read;

using Entities;

public interface INotificationsReadRepository
{
    Task<IReadOnlyCollection<Notification>> GetNotReadAsync(Guid receiverId, CancellationToken cancellationToken = default);
    Task<Notification?> GetOrDefaultAsync(Guid notificationId, Guid receiverId, CancellationToken cancellationToken = default);
}
