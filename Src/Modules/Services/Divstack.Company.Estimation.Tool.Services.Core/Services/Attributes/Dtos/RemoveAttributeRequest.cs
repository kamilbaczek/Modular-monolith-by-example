namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;

public record RemoveAttributeRequest
{
    public Guid AttributeId { get; set; }
    public Guid ServiceId { get; set; }
}
