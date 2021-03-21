using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Exceptions
{
    internal sealed class CategoryNotFoundException : InvalidOperationException
    {
        public CategoryNotFoundException(Guid id) : base($"Category: {id} not found")
        {
        }
    }
}
