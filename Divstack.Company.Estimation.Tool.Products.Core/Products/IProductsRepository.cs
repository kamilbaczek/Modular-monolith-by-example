using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products
{
    public interface IProductsRepository
    {
        Task AddAsync(Product product, CancellationToken cancellationToken = default);
        Task DeleteAsync(Product product, CancellationToken cancellationToken = default);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product> GetAsync(Guid publicId, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);

    }
}
