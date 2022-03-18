namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using Valuations.Domain.Valuations;

internal sealed class ValuationsNotificationsNotificationsContext : IValuationsNotificationsContext
{
    private const string DatabaseName = "EstimationTool";
    private const string ValuationsCollectionName = "ValuationsNotifications";

    private readonly IMongoDatabase _database;

    public ValuationsNotificationsNotificationsContext(MongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase(DatabaseName);
    }

    public IMongoCollection<Valuation> Valuations => _database.GetCollection<Valuation>(ValuationsCollectionName);
}
