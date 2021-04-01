using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues.Dtos
{
    public sealed class CreatePossibleValueRequest
    {
        public string Value { get; set; }
        public Guid ProductId { get; set; }
        public Guid AttributeId { get; set; }
    }
}
