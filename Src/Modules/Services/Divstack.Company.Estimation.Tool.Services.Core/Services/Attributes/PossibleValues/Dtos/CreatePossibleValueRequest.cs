namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos;

using System;

public sealed class CreatePossibleValueRequest
{
    public string Value { get; set; }
    public Guid ServiceId { get; set; }
    public Guid AttributeId { get; set; }
}
