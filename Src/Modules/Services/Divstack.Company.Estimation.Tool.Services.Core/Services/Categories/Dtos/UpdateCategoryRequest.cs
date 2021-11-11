using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;

public sealed class UpdateCategoryRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ServiceId { get; set; }
}
