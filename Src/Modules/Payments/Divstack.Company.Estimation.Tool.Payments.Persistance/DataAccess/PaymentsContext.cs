namespace Divstack.Company.Estimation.Tool.Payments.Persistance.DataAccess;

using MongoDB.Driver;
using Payments.Domain.Payments;

internal sealed class PaymentsContext : IPaymentsContext
{
    private const string DatabaseName = "EstimationTool";
    private const string PaymentsCollectionName = "Payments";

    private readonly IMongoDatabase _database;

    public PaymentsContext(MongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase(DatabaseName);
    }

    public IMongoCollection<Payment> Payments => _database.GetCollection<Payment>(PaymentsCollectionName);
}
