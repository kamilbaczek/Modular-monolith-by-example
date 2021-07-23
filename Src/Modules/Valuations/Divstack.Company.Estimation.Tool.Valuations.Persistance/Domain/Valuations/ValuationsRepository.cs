using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Domain.Valuations
{
    internal sealed class ValuationsRepository : IValuationsRepository
    {
        private readonly ValuationsContext _valuationsContext;

        public ValuationsRepository(ValuationsContext valuationsContext)
        {
            _valuationsContext = valuationsContext;
        }

        public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
        {
            return await _valuationsContext.Valuations.SingleOrDefaultAsync(valuations => valuations.Id == valuationId,
                cancellationToken);
        }

        public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
        {
            await _valuationsContext.Valuations.AddAsync(valuation, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _valuationsContext.SaveChangesAsync(cancellationToken);
        }
    }
}
