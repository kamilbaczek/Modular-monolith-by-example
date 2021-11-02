using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll
{
    internal sealed class GetAllValuationsQueryHandler : IRequestHandler<GetAllValuationsQuery, ValuationListVm>
    {
        private readonly IReadRepository _readRepository;

        public GetAllValuationsQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<ValuationListVm> Handle(GetAllValuationsQuery request, CancellationToken cancellationToken)
        {
            var valuationListItemDtos = await _readRepository.GetAllAsync(cancellationToken);
            
            return new ValuationListVm(valuationListItemDtos);
        }
    }
}