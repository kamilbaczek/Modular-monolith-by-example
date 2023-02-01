namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

using System;
using System.Text.Json.Serialization;
using Categories.Dtos;

public sealed record ServiceDto(Guid Id, string Name, string Description, CategoryDto Category, Guid CreatedBy)
{
    internal static ServiceDto Map(Service service)
    {
        var category = CategoryDto.Map(service.Category);
        return new ServiceDto(service.Id, service.Name, service.Description, category, service.CreatedBy);
    }
}
