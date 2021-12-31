namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;

using MediatR;

internal sealed class CompleteCommandHandler : IRequestHandler<CompleteCommand>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IValuationsRepository _valuationsRepository;

    public CompleteCommandHandler(IValuationsRepository valuationsRepository,
        ICurrentUserService currentUserService,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _valuationsRepository = valuationsRepository;
        _currentUserService = currentUserService;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async Task<Unit> Handle(CompleteCommand command, CancellationToken cancellationToken)
    {
        var valuationId = new ValuationId(command.ValuationId);
        var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
        if (valuation is null)
        {
            throw new NotFoundException(command.ValuationId, nameof(Valuation));
        }

        var employeeId = new EmployeeId(_currentUserService.GetPublicUserId());
        valuation.Complete(employeeId);

        await _valuationsRepository.CommitAsync(valuation, cancellationToken);
        await _integrationEventPublisher.PublishAsync(valuation.DomainEvents, cancellationToken);

        return Unit.Value;
    }
}
