using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos
{
    public sealed class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}