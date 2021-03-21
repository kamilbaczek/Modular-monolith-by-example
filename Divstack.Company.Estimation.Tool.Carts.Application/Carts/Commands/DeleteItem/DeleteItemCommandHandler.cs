using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts;
using Divstack.Company.Estimation.Tool.Carts.Domain.UserAccess;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.DeleteItem
{
    internal sealed class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteItemCommandHandler(ICartRepository cartRepository,
            ICurrentUserService currentUserService)
        {
            _cartRepository = cartRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetPublicUserId();
            var cart = await _cartRepository.GetActiveAsync(userId, cancellationToken);
            cart.RemoveItem(request.ProductId);
            await _cartRepository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
