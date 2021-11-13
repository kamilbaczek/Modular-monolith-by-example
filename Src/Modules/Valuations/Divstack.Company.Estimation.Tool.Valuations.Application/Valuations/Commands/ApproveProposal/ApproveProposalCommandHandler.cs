namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;

using System.Threading;
using System.Threading.Tasks;
using Domain.Valuations;
using Domain.Valuations.Proposals;
using Exceptions;
using Interfaces;
using MediatR;

internal sealed class ApproveProposalCommandHandler : IRequestHandler<ApproveProposalCommand>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IValuationsRepository _valuationsRepository;

    public ApproveProposalCommandHandler(
        IValuationsRepository valuationsRepository,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _valuationsRepository = valuationsRepository;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async Task<Unit> Handle(ApproveProposalCommand command, CancellationToken cancellationToken)
    {
        var valuationId = new ValuationId(command.ValuationId);
        var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
        if (valuation is null)
        {
            throw new NotFoundException(command.ValuationId, nameof(Valuation));
        }

        var proposalId = new ProposalId(command.ProposalId);

        valuation.ApproveProposal(proposalId);

        await _valuationsRepository.CommitAsync(valuation, cancellationToken);
        _integrationEventPublisher.Publish(valuation.DomainEvents);

        return Unit.Value;
    }
}
