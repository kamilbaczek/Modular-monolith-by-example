namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using MongoDB.Driver;

internal sealed class ServicesContext : IServicesContext
{
    private const string DatabaseName = "EstimationTool";
    private const string ServicesCollectionName = "Services";
    private const string CategoriesCollectionName = "Categories";

    private readonly IMongoDatabase _database;

    public ServicesContext(MongoClient mongoClient) =>
        _database = mongoClient.GetDatabase(DatabaseName);

    public IMongoCollection<Service> Services => _database.GetCollection<Service>(ServicesCollectionName);
    public IMongoCollection<Category> Categories => _database.GetCollection<Category>(CategoriesCollectionName);
}
