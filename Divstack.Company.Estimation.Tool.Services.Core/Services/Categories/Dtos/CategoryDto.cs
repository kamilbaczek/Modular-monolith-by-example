using System;
using System.Text.Json.Serialization;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories.Dtos
{
    public sealed class CategoryDto
    {
        [JsonConstructor]
        public CategoryDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        internal static CategoryDto Map(Category category)
        {
            return new CategoryDto(category.Id, category.Name);
        }
    }
}
