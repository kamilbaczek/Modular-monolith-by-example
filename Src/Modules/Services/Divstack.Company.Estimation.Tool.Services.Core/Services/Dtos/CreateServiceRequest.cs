namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

using System;

public sealed class CreateServiceRequest
{
    public string Name { get; init; }
    public string Description { get; init; }
    public Guid CategoryId { get; init; }
}
