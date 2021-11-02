using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get
{
    internal sealed class GetValuationsQueryHandler : IRequestHandler<GetValuationQuery, ValuationVm>
    {
        private readonly IReadRepository _readRepository;

        public GetValuationsQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        
        public async Task<ValuationVm> Handle(GetValuationQuery request, CancellationToken cancellationToken)
        {
            var valuationId = ValuationId.Of(request.ValuationId);
            var valuationInformationDto = await _readRepository.GetValuation(valuationId, cancellationToken);
            
            return new ValuationVm(valuationInformationDto);
        }
    }
}