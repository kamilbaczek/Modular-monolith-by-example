using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Exceptions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete
{
    internal sealed class CompleteCommandHandler : IRequestHandler<CompleteCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IValuationsRepository _valuationsRepository;

        public CompleteCommandHandler(IValuationsRepository valuationsRepository,
            ICurrentUserService currentUserService)
        {
            _valuationsRepository = valuationsRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CompleteCommand command, CancellationToken cancellationToken)
        {
            var valuationId = new ValuationId(command.ValuationId);
            var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
            if (valuation is null)
                throw new NotFoundException(command.ValuationId, nameof(Valuation));
            var employeeId = new EmployeeId(_currentUserService.GetPublicUserId());

            valuation.Complete(employeeId);
            await _valuationsRepository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
