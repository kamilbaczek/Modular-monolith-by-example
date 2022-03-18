namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using Valuations.Domain.Valuations;

internal interface IValuationsNotificationsContext
{
    public IMongoCollection<Valuation> Valuations { get; }
}
