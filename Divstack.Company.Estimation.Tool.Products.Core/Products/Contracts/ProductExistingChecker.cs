using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts
{
    internal sealed class ProductExistingChecker : IProductExistingChecker
    {
        private readonly IProductsRepository _productsRepository;

        public ProductExistingChecker(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<bool> ExistAsync(Guid productId)
        {
            var product = await _productsRepository.GetAsync(productId);

            return product is not null;
        }

        public async Task<bool> ExistAsync(List<Guid> productIds)
        {
            var products = await _productsRepository.GetAllAsync();
            var productsIdsFromDb = products.Select(product => product.Id).ToList();
            var allExists = productIds.All(id => productsIdsFromDb.Contains(id));

            return allExists;
        }
    }
}
