namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.DataAccess;

using MongoDB.Driver;
using Tool.Priorities.Domain;

internal sealed class PrioritiesContext : IPrioritiesContext
{
    private const string DatabaseName = "EstimationTool";
    private const string PrioritiesCollectionName = "Priorities";

    private readonly IMongoDatabase _database;

    public PrioritiesContext(MongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase(DatabaseName);
    }

    public IMongoCollection<Priority> Priorities => _database.GetCollection<Priority>(PrioritiesCollectionName);
}
