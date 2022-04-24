namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;

using MediatR;
using Request;
using Shared.DDD.ValueObjects;

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
        await _integrationEventPublisher.PublishAsync(valuation.DomainEvents, cancellationToken);
        return Unit.Value;
    }
}
