namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using MongoDB.Driver;
using Valuations.Domain.Valuations;

internal interface IValuationsContext
{
    public IMongoCollection<Valuation> Valuations { get; }
}
