using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess
{
    internal sealed class ValuationsContext : IValuationsContext
    {
        private const string DatabaseName = "EstimationTool";
        private const string ValuationsCollectionName = "Valuations";

        private readonly IMongoDatabase _database;
        
        public ValuationsContext(MongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(DatabaseName);
        }
        
        public async Task<IReadOnlyCollection<TProjection>> ExecuteRaw<TProjection>(string query)
        {
          return await _database.RunCommandAsync<IReadOnlyCollection<TProjection>>(query);
        }

        public IMongoCollection<Valuation> Valuations => _database.GetCollection<Valuation>(ValuationsCollectionName);
    }
}