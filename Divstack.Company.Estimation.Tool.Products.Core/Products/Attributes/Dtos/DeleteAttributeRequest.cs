using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.Dtos
{
    public sealed class DeleteAttributeRequest
    {
        public Guid AttributeId { get; set; }
        public Guid ProductId { get; set; }
    }
}