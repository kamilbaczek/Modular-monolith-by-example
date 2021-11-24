namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using PossibleValues;
using PossibleValues.Exceptions;

public sealed class Attribute
{
    private Attribute(Service service, string name)
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
    private Service Service { get; }

    internal static Attribute Create(Service service, string name)
    {
        return new Attribute(service, name);
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
        {
            throw new PossibleValueNotFoundException(id);
        }

        PossibleValues.Remove(possibleValueToRemove);
    }
}
