namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.DataAccess;

using MongoDB.Driver;
using Tool.Priorities.Domain;

internal interface IPrioritiesContext
{
    public IMongoCollection<Priority> Priorities { get; }
}
