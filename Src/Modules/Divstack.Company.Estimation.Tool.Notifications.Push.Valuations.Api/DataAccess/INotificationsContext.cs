namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.DataAccess;

using Domain;
using MongoDB.Driver;

internal interface INotificationsContext
{
    public IMongoCollection<Notification> Notifications { get; }
}
