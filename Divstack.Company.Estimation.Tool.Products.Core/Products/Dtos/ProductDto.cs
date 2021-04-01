using System;
using System.Text.Json.Serialization;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Dtos;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos
{
    public sealed class ProductDto
    {
        [JsonConstructor]
        private ProductDto()
        {
        }

        private ProductDto(Guid id, string name, string description, CategoryDto category, Guid createdBy)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            CreatedBy = createdBy;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CreatedBy { get; private set; }

        public CategoryDto Category { get; private set; }

        internal static ProductDto Map(Product product)
        {
            var category = CategoryDto.Map(product.Category);
            return new ProductDto(product.Id, product.Name, product.Description, category, product.CreatedBy);
        }
    }
}
