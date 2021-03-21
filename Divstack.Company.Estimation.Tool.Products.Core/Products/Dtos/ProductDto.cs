using System;
using System.Text.Json.Serialization;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Dtos;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos
{
    public sealed class ProductDto
    {
        [JsonConstructor]
        public ProductDto(Guid id, string name, string description, CategoryDto category, Guid createdBy)
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

        internal static ProductDto Map(Product product)
        {
            var category = CategoryDto.Map(product.Category);
            return new ProductDto(product.Id, product.Name, product.Description, category, product.CreatedBy);
        }
    }
}
