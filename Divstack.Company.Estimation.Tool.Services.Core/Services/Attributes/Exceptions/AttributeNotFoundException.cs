using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Exceptions
{
    internal sealed class AttributeNotFoundException : InvalidOperationException
    {
        public AttributeNotFoundException(Guid id) : base($"Attribute: {id} not found")
        {
        }
    }
}
