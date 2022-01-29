namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Read;

using Entities;

public interface INotificationsReadRepository
{
    Task<IReadOnlyCollection<Notification>> GetAllAsync(Guid receiverId, CancellationToken cancellationToken = default);
    Task<Notification?> GetOrDefaultAsync(Guid notificationId, CancellationToken cancellationToken = default);
}
