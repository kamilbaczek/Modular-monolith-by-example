using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Application.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal
{
    internal sealed class SuggestProposalCommandHandler : IRequestHandler<SuggestProposalCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IIntegrationEventPublisher _integrationEventPublisher;
        private readonly IValuationsRepository _valuationsRepository;

        public SuggestProposalCommandHandler(IValuationsRepository valuationsRepository,
            ICurrentUserService currentUserService,
            IIntegrationEventPublisher integrationEventPublisher)
        {
            _valuationsRepository = valuationsRepository;
            _currentUserService = currentUserService;
            _integrationEventPublisher = integrationEventPublisher;
        }

        public async Task<Unit> Handle(SuggestProposalCommand command, CancellationToken cancellationToken)
        {
            var valuationId = ValuationId.Of(command.ValuationId);
            var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
            if (valuation is null)
                throw new NotFoundException(command.ValuationId, nameof(Valuation));
            
            var employeeId = EmployeeId.Of(_currentUserService.GetPublicUserId());
            var money = Money.Of(command.Value, command.Currency);

            valuation.SuggestProposal(money, command.Description, employeeId);

            await _valuationsRepository.CommitAsync(valuation, cancellationToken);
            _integrationEventPublisher.Publish(valuation.DomainEvents);
            return Unit.Value;
        }
    }
}