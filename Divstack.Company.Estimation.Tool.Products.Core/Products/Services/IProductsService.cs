using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Services
{
    public interface IProductsService
    {
        Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task CreateAsync(CreateProductRequest createProductRequest, CancellationToken cancellationToken = default);
        Task Update(UpdateProductRequest productToUpdate, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}