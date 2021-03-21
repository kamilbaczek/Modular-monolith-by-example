using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Exceptions
{
    internal sealed class ProductNotFoundException : InvalidOperationException
    {
        public ProductNotFoundException(Guid id) : base($"Product: {id} not found")
        {
        }
    }
}
