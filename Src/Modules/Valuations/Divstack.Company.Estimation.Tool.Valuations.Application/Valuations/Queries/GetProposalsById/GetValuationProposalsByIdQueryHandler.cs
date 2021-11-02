using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById
{
    internal sealed class
        GetValuationProposalsByIdQueryHandler : IRequestHandler<GetValuationProposalsByIdQuery, ValuationProposalsVm>
    {
        private readonly IReadRepository _readRepository;

        public GetValuationProposalsByIdQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<ValuationProposalsVm> Handle(GetValuationProposalsByIdQuery request,
            CancellationToken cancellationToken)
        {
            var valuationId = ValuationId.Of(request.ValuationId);
            var valuationProposalsVm = await _readRepository.GetProposals(valuationId, cancellationToken);
            return valuationProposalsVm;
        }
    }
}