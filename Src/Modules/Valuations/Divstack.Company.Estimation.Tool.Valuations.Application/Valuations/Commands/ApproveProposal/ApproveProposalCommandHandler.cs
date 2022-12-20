namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;

using Domain.Valuations.Proposals;
using Domain.Valuations.States;
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
        var valuationNegotiating = await _valuationsRepository.GetAsync<ValuationNegotiation>(valuationId, cancellationToken);
        if (valuationNegotiating is null)
            throw new NotFoundException(command.ValuationId, nameof(ValuationNegotiation));

        var proposalId = new ProposalId(command.ProposalId);
        var valuationApproved = valuationNegotiating.ApproveProposal(proposalId);

        await _valuationsRepository.CommitAsync(valuationApproved, cancellationToken);
        await _integrationEventPublisher.PublishAsync(valuationApproved.DomainEvents, cancellationToken);

        return Unit.Value;
    }
}
