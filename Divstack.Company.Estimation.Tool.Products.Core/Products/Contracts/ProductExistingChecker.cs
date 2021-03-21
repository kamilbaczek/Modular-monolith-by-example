using System;
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
    }
}