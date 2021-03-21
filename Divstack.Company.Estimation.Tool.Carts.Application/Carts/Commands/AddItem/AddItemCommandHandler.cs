using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts;
using Divstack.Company.Estimation.Tool.Carts.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.AddItem
{
    internal sealed class AddItemCommandHandler : IRequestHandler<AddItemCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IProductExistingChecker _productExistingChecker;

        public AddItemCommandHandler(ICartRepository cartRepository,
            ICurrentUserService currentUserService,
            IProductExistingChecker productExistingChecker)
        {
            _cartRepository = cartRepository;
            _currentUserService = currentUserService;
            _productExistingChecker = productExistingChecker;
        }

        public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetPublicUserId();
            var cart = await GetOrCreateActiveCart(userId, cancellationToken);
            await cart.AddItemAsync(
                request.ProductId,
                request.Quantity,
                _productExistingChecker);

            return Unit.Value;
        }

        private async Task<Cart> GetOrCreateActiveCart(Guid userId, CancellationToken cancellationToken)
        {
            var activeCart = await _cartRepository.GetActiveOrDefaultAsync(userId, cancellationToken);
            if (activeCart is not null) return activeCart;
            activeCart = Cart.Create(userId);
            await _cartRepository.AddAsync(activeCart, cancellationToken);

            return activeCart;
        }
    }
}
