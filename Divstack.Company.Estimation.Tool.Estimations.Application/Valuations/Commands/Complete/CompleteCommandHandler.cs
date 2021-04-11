using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.Complete
{
    internal sealed class CompleteCommandHandler : IRequestHandler<CompleteCommand>
    {
        private readonly IValuationsRepository _valuationsRepository;
        private readonly ICurrentUserService _currentUserService;

        public CompleteCommandHandler(IValuationsRepository valuationsRepository, ICurrentUserService currentUserService)
        {
            _valuationsRepository = valuationsRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CompleteCommand command, CancellationToken cancellationToken)
        {
            var valuationId = new ValuationId(command.ValuationId);
            var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
            var employeeId = new EmployeeId(_currentUserService.GetPublicUserId());

            valuation.Complete(employeeId);
            await _valuationsRepository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
