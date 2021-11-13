namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Services;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dtos;

public interface ICategoriesService
{
    Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Guid> CreateAsync(CreateCategoryRequest createCategoryRequest,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
