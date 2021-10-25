using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries
{
    public interface IReadRepository
    {
        Task<IReadOnlyCollection<ValuationListItemDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}