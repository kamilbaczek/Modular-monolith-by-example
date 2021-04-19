using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal
{
    internal sealed class CancelProposalCommandHandler : IRequestHandler<CancelProposalCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IValuationsRepository _valuationsRepository;

        public CancelProposalCommandHandler(IValuationsRepository valuationsRepository,
            ICurrentUserService currentUserService)
        {
            _valuationsRepository = valuationsRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CancelProposalCommand command, CancellationToken cancellationToken)
        {
            var valuationId = new ValuationId(command.ValuationId);
            var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
            var proposalId = new ProposalId(command.ProposalId);
            var employeeId = new EmployeeId(_currentUserService.GetPublicUserId());

            valuation.CancelProposal(proposalId, employeeId);

            await _valuationsRepository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}