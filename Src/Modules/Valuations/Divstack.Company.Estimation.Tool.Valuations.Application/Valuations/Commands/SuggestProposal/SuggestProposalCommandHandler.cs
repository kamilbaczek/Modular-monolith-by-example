namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;

using Domain.Valuations.States;
using MediatR;
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
        var valuationRequested = await _valuationsRepository.GetAsync<ValuationRequested>(valuationId, cancellationToken);
        if (valuationRequested is null)
            throw new NotFoundException(command.ValuationId, nameof(ValuationRequested));

        var employeeId = EmployeeId.Of(_currentUserService.GetPublicUserId());
        var money = Money.Of(command.Value, command.Currency!);

        var suggestProposal = valuationRequested.SuggestProposal(money, command.Description!, employeeId);
        
        await _valuationsRepository.CommitAsync(suggestProposal, cancellationToken);
        await _integrationEventPublisher.PublishAsync(suggestProposal.DomainEvents, cancellationToken);

        return Unit.Value;
    }
}
