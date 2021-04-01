using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.Dtos
{
    public sealed class CreateAttributeRequest
    {
        public string Name { get; set; }
        public Guid ProductId { get; set; }
    }
}
