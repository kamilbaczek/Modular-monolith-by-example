namespace Divstack.Company.Estimation.Tool.Push.DataAccess.DataAccess.Context;

using Entities;
using MongoDB.Driver;

internal sealed class NotificationsContext : INotificationsContext
{
    private const string DatabaseName = "EstimationTool";
    private const string CollectionName = "Notifications";

    private readonly IMongoDatabase _database;

    public NotificationsContext(MongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase(DatabaseName);
    }

    public IMongoCollection<Notification> Notifications => _database.GetCollection<Notification>(CollectionName);
}
