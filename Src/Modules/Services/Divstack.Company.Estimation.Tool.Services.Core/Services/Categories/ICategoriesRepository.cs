namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ICategoriesRepository
{
    Task AddAsync(Category category, CancellationToken cancellationToken = default);
    Task DeleteAsync(Category category, CancellationToken cancellationToken = default);
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Category> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
