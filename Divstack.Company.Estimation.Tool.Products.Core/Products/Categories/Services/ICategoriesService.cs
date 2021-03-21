using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Services
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task CreateAsync(CreateCategoryRequest createCategoryRequest, CancellationToken cancellationToken = default);
        Task Update(UpdateCategoryRequest updateCategoryRequest, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}