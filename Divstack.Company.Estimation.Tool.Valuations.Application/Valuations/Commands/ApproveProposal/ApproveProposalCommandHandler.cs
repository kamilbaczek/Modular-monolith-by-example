using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal
{
    internal sealed class ApproveProposalCommandHandler : IRequestHandler<ApproveProposalCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IValuationsRepository _valuationsRepository;

        public ApproveProposalCommandHandler(IValuationsRepository valuationsRepository, IEventPublisher eventPublisher)
        {
            _valuationsRepository = valuationsRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<Unit> Handle(ApproveProposalCommand command, CancellationToken cancellationToken)
        {
            var valuationId = new ValuationId(command.ValuationId);
            var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
            var proposalId = new ProposalId(command.ProposalId);

            valuation.ApproveProposal(proposalId);

            await _valuationsRepository.CommitAsync(cancellationToken);
            _eventPublisher.Publish(valuation.DomainEvents);

            return Unit.Value;
        }
    }
}