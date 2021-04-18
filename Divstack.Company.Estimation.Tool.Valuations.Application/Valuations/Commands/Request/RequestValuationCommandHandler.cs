using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    internal sealed class RequestValuationCommandHandler : IRequestHandler<RequestValuationCommand>
    {
        private readonly IValuationsRepository _valuationsRepository;
        private readonly IServiceExistingChecker _serviceExistingChecker;

        public RequestValuationCommandHandler(IValuationsRepository valuationsRepository,
            IServiceExistingChecker serviceExistingChecker)
        {
            _valuationsRepository = valuationsRepository;
            _serviceExistingChecker = serviceExistingChecker;
        }

        public async Task<Unit> Handle(RequestValuationCommand requestValuation, CancellationToken cancellationToken)
        {
            var email = Email.Of(requestValuation.Email);
            var client = Client.Of(email, requestValuation.FirstName, requestValuation.LastName);
            var serviceIds = requestValuation.ServicesIds
                                                          .Select(id => new ServiceId(id))
                                                          .ToList();
            var valuation = await Valuation.RequestAsync(serviceIds, client, _serviceExistingChecker);
            await _valuationsRepository.AddAsync(valuation, cancellationToken);
            await _valuationsRepository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
