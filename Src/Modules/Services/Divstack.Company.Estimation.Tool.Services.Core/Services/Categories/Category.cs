namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;

using System;

public sealed class Category
{
    private Category(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

    public static Category Create(string name, string description)
    {
        return new Category(name, description);
    }
}
