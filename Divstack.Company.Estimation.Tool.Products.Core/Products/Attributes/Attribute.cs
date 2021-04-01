using System;
using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Products.Core.Attributes.PossibleValues;
using Divstack.Company.Estimation.Tool.Products.Core.Attributes.PossibleValues.Exceptions;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes
{
    public sealed class Attribute
    {
        private Attribute(Product product,string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            PossibleValues = new List<PossibleValue>();
        }

        private Attribute()
        {
        }

        internal IList<PossibleValue> PossibleValues { get; }
        internal Guid Id { get; }
        internal string Name { get; }
        private Product Product { get; }

        internal static Attribute Create(Product product, string name)
        {
            return new Attribute(product, name);
        }

        internal void AddPossibleValue(string value)
        {
            var possibleValue = PossibleValue.Create(this, value);
            PossibleValues.Add(possibleValue);
        }

        internal void DeletePossibleValue(Guid id)
        {
            var possibleValueToRemove = PossibleValues.SingleOrDefault(value => value.Id == id);
            if (possibleValueToRemove is null)
                throw new PossibleValueNotFoundException(id);
            PossibleValues.Remove(possibleValueToRemove);
        }
    }
}
