using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess
{
    internal interface IValuationsContext
    {
        public IMongoCollection<Valuation> Valuations { get; }
        Task<IReadOnlyCollection<TProjection>> ExecuteRaw<TProjection>(string query);
    }
}