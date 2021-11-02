using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById
{
    internal sealed class
        GetValuationHistoryByIdQueryHandler : IRequestHandler<GetValuationHistoryByIdQuery, ValuationHistoryVm>
    {
        private readonly IReadRepository _readRepository;

        public GetValuationHistoryByIdQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<ValuationHistoryVm> Handle(GetValuationHistoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var historyVm = await _readRepository.GetAllHistoricalEntries(cancellationToken);

            return historyVm;
        }
    }
}