using System;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.Core.UserAccess;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products
{
    public sealed class Product
    {
        private Product()
        {
        }

        private Product(
            string name,
            string description,
            Category category,
            ICurrentUserService currentUserService)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            CreatedBy = currentUserService.GetPublicUserId();
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }

        public Guid CreatedBy { get; }

        public static Product Create(string name, string description, Category category, ICurrentUserService currentUserService)
        {
            return new(name, description, category, currentUserService);
        }

        public void Update(string name, string description, Category category)
        {
            Name = name;
            Description = description;
            Category = category;
        }
    }
}
