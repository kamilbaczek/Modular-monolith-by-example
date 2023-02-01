namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos;

public sealed record CreateCategoryRequest(string Name, string Description)
{
    internal static CreateCategoryRequest Create(string name, string description) => 
        new(name, description);
}
