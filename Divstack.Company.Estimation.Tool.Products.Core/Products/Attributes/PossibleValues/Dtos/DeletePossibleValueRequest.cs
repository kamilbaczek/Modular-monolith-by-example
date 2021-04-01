using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues.Dtos
{
    public sealed class DeletePossibleValueRequest
    {
        public Guid ProductId { get; set; }

        public Guid PossibleValueId { get; set; }
        public Guid AttributeId { get; set; }
    }
}
