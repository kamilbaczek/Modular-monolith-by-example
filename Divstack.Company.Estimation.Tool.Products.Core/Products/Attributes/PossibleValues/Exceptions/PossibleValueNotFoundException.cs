using System;

namespace Divstack.Company.Estimation.Tool.Products.Core.Attributes.PossibleValues.Exceptions
{
    internal sealed class PossibleValueNotFoundException : InvalidOperationException
    {
        public PossibleValueNotFoundException(Guid id) : base($"Attribute possible value: {id} not found")
        {
        }
    }
}
