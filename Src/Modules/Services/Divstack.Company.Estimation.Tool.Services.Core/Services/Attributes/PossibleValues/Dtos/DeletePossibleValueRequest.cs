namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos;

using System;

public sealed class DeletePossibleValueRequest
{
    public Guid ServiceId { get; set; }

    public Guid PossibleValueId { get; set; }
    public Guid AttributeId { get; set; }
}
