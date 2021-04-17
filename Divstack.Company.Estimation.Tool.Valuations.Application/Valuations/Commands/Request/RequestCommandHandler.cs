using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    internal sealed class RequestCommandHandler : IRequestHandler<RequestCommand>
    {
        private readonly IValuationsRepository _valuationsRepository;
        private readonly IServiceExistingChecker _serviceExistingChecker;

        public RequestCommandHandler(IValuationsRepository valuationsRepository,
            IServiceExistingChecker serviceExistingChecker)
        {
            _valuationsRepository = valuationsRepository;
            _serviceExistingChecker = serviceExistingChecker;
        }

        public async Task<Unit> Handle(RequestCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Of(request.Email);
            var client = Client.Of(email, request.FirstName, request.LastName);
            var serivceIds = request.ProductsIds
                                                          .Select(id => new ServiceId(id))
                                                          .ToList();
            var valuation = await Valuation.RequestAsync(serivceIds, client, _serviceExistingChecker);
            await _valuationsRepository.AddAsync(valuation, cancellationToken);
            await _valuationsRepository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
