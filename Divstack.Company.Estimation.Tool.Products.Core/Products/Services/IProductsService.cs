using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Services
{
    public interface IProductsService
    {
        Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task CreateAsync(CreateProductRequest createProductRequest, CancellationToken cancellationToken = default);
        Task Update(UpdateProductRequest productToUpdate, CancellationToken cancellationToken = default);

        Task AddAttributeAsync(CreateAttributeRequest createAttributeRequest,
            CancellationToken cancellationToken = default);

        Task RemoveAttributeAsync(DeleteAttributeRequest deleteAttributeRequest,
            CancellationToken cancellationToken = default);

        Task AddAttributePossibleValueAsync(CreatePossibleValueRequest createPossibleValueRequest,
            CancellationToken cancellationToken = default);

        Task RemoveAttributePossibleValueAsync(DeletePossibleValueRequest deleteAttributeRequest,
            CancellationToken cancellationToken = default);
       Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
