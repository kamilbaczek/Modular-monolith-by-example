namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;

using System;

public record RemoveAttributeRequest
{
    public Guid AttributeId { get; set; }
    public Guid ServiceId { get; set; }
}
