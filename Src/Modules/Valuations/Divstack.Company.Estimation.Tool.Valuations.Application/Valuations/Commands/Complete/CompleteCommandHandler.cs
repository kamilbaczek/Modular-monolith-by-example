namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;

using Domain.Valuations.States;
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
        var valuationId = ValuationId.Of(command.ValuationId);
        var valuationApproved = await _valuationsRepository.GetAsync<ValuationApproved>(valuationId, cancellationToken);
        if (valuationApproved is null)
        {
            throw new NotFoundException(command.ValuationId, nameof(ValuationApproved));
        }

        var employeeId = EmployeeId.Of(_currentUserService.GetPublicUserId());
         var completed = valuationApproved.Complete(employeeId);

        await _valuationsRepository.CommitAsync(completed, cancellationToken);
        await _integrationEventPublisher.PublishAsync(completed.DomainEvents, cancellationToken);

        return Unit.Value;
    }
}
