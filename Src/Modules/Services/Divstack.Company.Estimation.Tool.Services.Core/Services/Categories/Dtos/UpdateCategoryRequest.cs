namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;

using System;

public sealed class UpdateCategoryRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ServiceId { get; set; }
}
