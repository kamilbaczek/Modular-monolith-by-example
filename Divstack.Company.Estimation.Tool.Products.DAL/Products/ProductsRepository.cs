using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Products
{
    internal sealed class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _productsContext;

        public ProductsRepository(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _productsContext.AddAsync(product, cancellationToken);
            await _productsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
        {
            _productsContext.Products.Remove(product);
            await _productsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _productsContext.Products
                .Include(product => product.Category)
                .OrderBy(product => product.Name)
                .ThenBy(product => product.Description)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product> GetAsync(Guid publicId, CancellationToken cancellationToken = default)
        {
            return await _productsContext.Products
                .Include(product => product.Category)
                .Include(product => product.Attributes)
                .ThenInclude(attribute =>  attribute.PossibleValues)
                .SingleOrDefaultAsync(product => product.Id == publicId, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _productsContext.SaveChangesAsync(cancellationToken);
        }
    }
}
