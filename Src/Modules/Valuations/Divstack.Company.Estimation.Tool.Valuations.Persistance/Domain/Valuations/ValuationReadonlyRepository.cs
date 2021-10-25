using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations
{
    internal class ValuationReadonlyRepository : IReadRepository
    {
        private readonly IValuationsContext _valuationsContext;

        public ValuationReadonlyRepository(IValuationsContext valuationsContext)
        {
            _valuationsContext = valuationsContext;
        }
        public async Task<IReadOnlyCollection<ValuationListItemDto>> GetAllAsync(CancellationToken cancellationToken)
        {
             var projectionQuery = @"{ Id: '$_id.Value', InquiryId: '$InquiryId.Value', CompletedBy: 1, RequestedDate: 1, _id:0}";
             var filterDefinition = FilterDefinition<Valuation>.Empty;
             var valuationListItemDtos = await _valuationsContext.Valuations
                .Find(filterDefinition)
                .Project<ValuationListItemDto>(projectionQuery)
                .ToListAsync(cancellationToken);
           
            return valuationListItemDtos;
        }
    }
}