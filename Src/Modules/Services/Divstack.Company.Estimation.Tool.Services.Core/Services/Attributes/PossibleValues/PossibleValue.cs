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

    public PossibleValue()
    {
    }

    internal Guid Id { get; set; }
    internal string Value { get; set; }
    private Attribute Attribute { get; set; }

    internal static PossibleValue Create(Attribute attribute, string value)
    {
        return new PossibleValue(attribute, value);
    }
}
