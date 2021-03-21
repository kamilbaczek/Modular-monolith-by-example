using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Exceptions;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Exceptions;
using Divstack.Company.Estimation.Tool.Products.Core.UserAccess;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Services
{
    internal sealed class ProductsService : IProductsService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository,
            ICategoriesRepository categoriesRepository,
            ICurrentUserService currentUserService)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
            _currentUserService = currentUserService;
        }

        public async Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var products = await _productsRepository.GetAllAsync(cancellationToken);
            var productsDtos = products.Select(ProductDto.Map).ToList();

            return productsDtos;
        }

        public async Task CreateAsync(CreateProductRequest createProductRequest,
            CancellationToken cancellationToken = default)
        {
            var category = await _categoriesRepository.GetAsync(createProductRequest.CategoryId, cancellationToken);
            ThrowIfCategoryNotFound(createProductRequest.CategoryId, category);
            var product = Product.Create(
                createProductRequest.Name,
                createProductRequest.Description,
                category,
                _currentUserService);
            await _productsRepository.AddAsync(product, cancellationToken);
        }

        public async Task Update(UpdateProductRequest updateProductRequest,
            CancellationToken cancellationToken = default)
        {
            var category = await _categoriesRepository.GetAsync(updateProductRequest.CategoryId, cancellationToken);
            ThrowIfCategoryNotFound(updateProductRequest.CategoryId, category);
            var product = await _productsRepository.GetAsync(updateProductRequest.ProductId, cancellationToken);
            ThrowIfProductNotFound(updateProductRequest.ProductId, product);
            product.Update(updateProductRequest.Name, updateProductRequest.Description, category);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productsRepository.GetAsync(id, cancellationToken);
            ThrowIfProductNotFound(id, product);
            await _productsRepository.DeleteAsync(product, cancellationToken);
        }

        private static void ThrowIfCategoryNotFound(Guid id, Category category)
        {
            if (category is null)
                throw new CategoryNotFoundException(id);
        }

        private static void ThrowIfProductNotFound(Guid id, Product product)
        {
            if (product is null)
                throw new ProductNotFoundException(id);
        }
    }
}
