namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues;

using System;
using Attribute = Attributes.Attribute;

public sealed class PossibleValue
{
    private PossibleValue(Attribute attribute, string value)
    {
        Id = Guid.NewGuid();
        Value = value;
    }

    private PossibleValue()
    {
    }

    internal Guid Id { get; }
    internal string Value { get; }
    private Attribute Attribute { get; }

    internal static PossibleValue Create(Attribute attribute, string value)
    {
        return new PossibleValue(attribute, value);
    }
}
