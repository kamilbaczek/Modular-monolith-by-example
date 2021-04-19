using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Services.DAL.Services.Categories
{
    internal sealed class CategoriesRepository : ICategoriesRepository
    {
        private readonly ServicesContext _servicesContext;

        public CategoriesRepository(ServicesContext servicesContext)
        {
            _servicesContext = servicesContext;
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _servicesContext.AddAsync(category, cancellationToken);
            await _servicesContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
        {
            _servicesContext.Categories.Remove(category);
            await _servicesContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _servicesContext.Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _servicesContext.Categories.SingleOrDefaultAsync(category => category.Id == id,
                cancellationToken);
        }
    }
}