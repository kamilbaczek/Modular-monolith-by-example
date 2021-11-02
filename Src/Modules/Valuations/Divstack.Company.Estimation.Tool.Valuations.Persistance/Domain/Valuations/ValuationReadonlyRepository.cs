using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations
{
    internal sealed class ValuationReadonlyRepository : IReadRepository
    {
        private readonly IValuationsContext _valuationsContext;

        public ValuationReadonlyRepository(IValuationsContext valuationsContext)
        {
            _valuationsContext = valuationsContext;
        }

        public async Task<IReadOnlyCollection<ValuationListItemDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            const string projectionQuery =
                @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: 1, RequestedDate: 1, _id:0}";
            var filterDefinition = FilterDefinition<Valuation>.Empty;
            var valuationListItemDtos = await _valuationsContext.Valuations
                .Find(filterDefinition)
                .Project<ValuationListItemDto>(projectionQuery)
                .ToListAsync(cancellationToken);

            return valuationListItemDtos;
        }

        public async Task<ValuationHistoryVm> GetAllHistoricalEntries(CancellationToken cancellationToken)
        {
            const string projectionQuery = @"{
            '_id':0,
            'ValuationHistoricalEntries':{
                '$map': {
                    'input':'$History',
                    'as':'historicalEntry',
                    'in':{
                        'Status':'$$historicalEntry.Status.Value',
                        'ChangeDate':'$$historicalEntry.ChangeDate',
                        'HistoricalEntryId':'$$historicalEntry.HistoricalEntryId.Value'
                    }
                }
            }
        }";
            var filterDefinition = FilterDefinition<Valuation>.Empty;
            var valuationHistoryVm = await _valuationsContext.Valuations
                .Find(filterDefinition)
                .Project<ValuationHistoryVm>(projectionQuery)
                .SingleOrDefaultAsync(cancellationToken);

            return valuationHistoryVm;
        }

        public async Task<ValuationProposalsVm> GetProposals(ValuationId valuationId,
            CancellationToken cancellationToken)
        {
            const string projectionQuery =
                @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: 1, RequestedDate: 1, _id:0}";
            var valuationProposalsVm = await _valuationsContext.Valuations
                .Find(valuation => valuation.Id == valuationId)
                .Project<ValuationProposalsVm>(projectionQuery)
                .SingleOrDefaultAsync(cancellationToken);

            return valuationProposalsVm;
        }

        public async Task<ValuationInformationDto> GetValuation(ValuationId valuationId,
            CancellationToken cancellationToken)
        {
            const string projectionQuery =
                @"{ ValuationId: '$_id.Value', Status:{$first:'$History.Status.Value'}, InquiryId: '$InquiryId.Value', CompletedBy: 1, RequestedDate: 1, _id:0}";
            var valuationInformationDto = await _valuationsContext.Valuations
                .Find(valuation => valuation.Id == valuationId)
                .Project<ValuationInformationDto>(projectionQuery)
                .SingleOrDefaultAsync(cancellationToken);
            return valuationInformationDto;
        }
    }
}