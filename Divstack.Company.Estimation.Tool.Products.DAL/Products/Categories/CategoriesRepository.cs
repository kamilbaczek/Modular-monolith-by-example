using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Products.Categories
{
    internal sealed class CategoriesRepository : ICategoriesRepository
    {
        private readonly ProductsContext _productsContext;

        public CategoriesRepository(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _productsContext.AddAsync(category, cancellationToken);
            await _productsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
        {
            _productsContext.Categories.Remove(category);
            await _productsContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _productsContext.Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _productsContext.Categories.SingleOrDefaultAsync(category => category.Id == id,
                cancellationToken);
        }
    }
}