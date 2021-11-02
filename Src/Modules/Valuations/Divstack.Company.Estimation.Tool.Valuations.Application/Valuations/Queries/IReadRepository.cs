using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries
{
    public interface IReadRepository
    {
        Task<IReadOnlyCollection<ValuationListItemDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ValuationHistoryVm> GetAllHistoricalEntries(CancellationToken cancellationToken);
        Task<ValuationProposalsVm> GetProposals(ValuationId valuationId, CancellationToken cancellationToken);
        Task<ValuationInformationDto> GetValuation(ValuationId valuationId, CancellationToken cancellationToken);
    }
}