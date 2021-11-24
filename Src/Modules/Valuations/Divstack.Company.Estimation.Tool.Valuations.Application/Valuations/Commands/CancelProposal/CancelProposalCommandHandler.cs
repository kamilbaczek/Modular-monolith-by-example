namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal;

using System.Threading;
using System.Threading.Tasks;
using Common.Exceptions;
using Domain.UserAccess;
using Domain.Valuations;
using Domain.Valuations.Proposals;
using MediatR;

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
        if (valuation is null)
        {
            throw new NotFoundException(command.ValuationId, nameof(Valuation));
        }

        var proposalId = new ProposalId(command.ProposalId);
        var employeeId = new EmployeeId(_currentUserService.GetPublicUserId());

        valuation.CancelProposal(proposalId, employeeId);

        await _valuationsRepository.CommitAsync(valuation, cancellationToken);

        return Unit.Value;
    }
}
