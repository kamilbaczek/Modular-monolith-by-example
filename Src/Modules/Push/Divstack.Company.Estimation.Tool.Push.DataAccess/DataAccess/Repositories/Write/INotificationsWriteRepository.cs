namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Repositories.Write;

using Entities;

public interface INotificationsWriteRepository
{
    Task UpdateAsync(Notification notification);
    Task AddAsync(Notification notification);
}
