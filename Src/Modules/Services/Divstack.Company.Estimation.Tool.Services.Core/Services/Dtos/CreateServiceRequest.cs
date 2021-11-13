namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

using System;

public sealed class CreateServiceRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
}
