namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using MongoDB.Driver;
using Valuations.Domain.Valuations;

internal interface IValuationsNotificationsContext
{
    public IMongoCollection<Valuation> Valuations { get; }
}
