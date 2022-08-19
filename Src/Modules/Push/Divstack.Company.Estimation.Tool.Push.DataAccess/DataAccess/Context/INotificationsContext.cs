namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Context;

using Entities;
using MongoDB.Driver;

internal interface INotificationsContext
{
    IMongoCollection<Notification> Notifications { get; }
}
