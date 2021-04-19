using System;
using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Carts.Domain.Carts
{
    public interface ICartRepository
    {
        Task AddAsync(Cart cart, CancellationToken cancellationToken = default);
        Task<Cart?> GetActiveOrDefaultAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<Cart> GetActiveAsync(Guid userId, CancellationToken cancellationToken = default);
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}