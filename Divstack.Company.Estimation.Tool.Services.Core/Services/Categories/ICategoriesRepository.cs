using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories
{
    public interface ICategoriesRepository
    {
        Task AddAsync(Category category, CancellationToken cancellationToken = default);
        Task DeleteAsync(Category category, CancellationToken cancellationToken = default);
        Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Category> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
