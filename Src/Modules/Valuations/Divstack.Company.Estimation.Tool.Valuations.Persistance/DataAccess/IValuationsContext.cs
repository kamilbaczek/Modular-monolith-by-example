using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess
{
    internal interface IValuationsContext
    {
        public IMongoCollection<Valuation> Valuations { get; }
    }
}