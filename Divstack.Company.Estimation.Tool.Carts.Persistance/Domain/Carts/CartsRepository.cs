using System;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Carts.Domain.Carts;
using Divstack.Company.Estimation.Tool.Carts.Persistance.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Carts.Persistance.Domain.Carts
{
    internal sealed class CartsRepository : ICartRepository
    {
        private readonly CartsContext _cartsContext;

        public CartsRepository(CartsContext cartsContext)
        {
            _cartsContext = cartsContext;
        }

        public async Task AddAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            await _cartsContext.Carts.AddAsync(cart, cancellationToken);
        }

        public async Task<Cart> GetActiveOrDefaultAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _cartsContext.Carts
                .SingleOrDefaultAsync(cart => cart.UserId == userId && cart.IsActive
                ,cancellationToken);
        }

        public async Task<Cart> GetActiveAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _cartsContext.Carts
                .SingleAsync(cart => cart.UserId == userId && cart.IsActive
                    ,cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _cartsContext.SaveChangesAsync(cancellationToken);
        }
    }
}
