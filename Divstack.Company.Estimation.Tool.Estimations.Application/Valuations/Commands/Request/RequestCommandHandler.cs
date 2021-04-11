using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.Request
{
    internal sealed class RequestCommandHandler : IRequestHandler<RequestCommand>
    {
        private readonly IValuationsRepository _valuationsRepository;
        private readonly IProductExistingChecker _productExistingChecker;

        public RequestCommandHandler(IValuationsRepository valuationsRepository,
            IProductExistingChecker productExistingChecker)
        {
            _valuationsRepository = valuationsRepository;
            _productExistingChecker = productExistingChecker;
        }

        public async Task<Unit> Handle(RequestCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Of(request.Email);
            var client = Client.Of(email, request.FirstName, request.LastName);
            var productsIds = request.ProductsIds
                                                          .Select(id => new ProductId(id))
                                                          .ToList();
            var valuation = await Valuation.RequestAsync(productsIds, client, _productExistingChecker);
            await _valuationsRepository.AddAsync(valuation, cancellationToken);
            await _valuationsRepository.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
