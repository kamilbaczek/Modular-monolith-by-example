using System;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts
{
    public interface IProductExistingChecker
    {
        Task<bool> ExistAsync(Guid productId);
    }
}
