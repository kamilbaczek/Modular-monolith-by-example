using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts;
using Divstack.Company.Estimation.Tool.Carts.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.AddItem
{
    internal sealed class AddItemCommandHandler : IRequestHandler<AddItemCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICurrentUserService _currentUserService;

        private readonly IServiceExistingChecker _serviceExistingChecker;

        public AddItemCommandHandler(ICartRepository cartRepository,
            ICurrentUserService currentUserService,
            IServiceExistingChecker serviceExistingChecker)
        {
            _cartRepository = cartRepository;
            _currentUserService = currentUserService;
            _serviceExistingChecker = serviceExistingChecker;
        }

        public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetPublicUserId();
            var cart = await GetOrCreateActiveCart(userId, cancellationToken);
            await cart.AddItemAsync(
                request.ServiceId,
                request.Quantity,
                _serviceExistingChecker);

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