namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using MongoDB.Driver;
using Valuations.Domain.Valuations;

internal sealed class ValuationsContext : IValuationsContext
{
    private const string DatabaseName = "EstimationTool";
    private const string ValuationsCollectionName = "Valuations";

    private readonly IMongoDatabase _database;

    public ValuationsContext(MongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase(DatabaseName);
    }

    public IMongoCollection<Valuation> Valuations => _database.GetCollection<Valuation>(ValuationsCollectionName);
}
