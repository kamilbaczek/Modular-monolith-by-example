namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

using System;
using System.Text.Json.Serialization;
using Categories.Dtos;

public sealed class ServiceDto
{
    [JsonConstructor]
    private ServiceDto()
    {
    }

    private ServiceDto(Guid id, string name, string description, CategoryDto category, Guid createdBy)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        CreatedBy = createdBy;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public Guid CreatedBy { get; }

    public CategoryDto Category { get; }

    internal static ServiceDto Map(Service service)
    {
        var category = CategoryDto.Map(service.Category);
        return new ServiceDto(service.Id, service.Name, service.Description, category, service.CreatedBy);
    }
}
