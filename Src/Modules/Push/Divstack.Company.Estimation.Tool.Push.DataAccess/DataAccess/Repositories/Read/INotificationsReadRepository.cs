namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Read;

using Entities;

public interface INotificationsReadRepository
{
    Task<IReadOnlyCollection<Notification>> GetAllAsync();
    Task<Notification?> GetOrDefaultAsync(Guid notificationId);
}
