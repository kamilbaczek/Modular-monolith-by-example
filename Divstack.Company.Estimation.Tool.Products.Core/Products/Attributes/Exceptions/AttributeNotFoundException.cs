using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Attributes.Exceptions
{
    internal sealed class AttributeNotFoundException : InvalidOperationException
    {
        public AttributeNotFoundException(Guid id) : base($"Attribute: {id} not found")
        {
        }
    }
}
