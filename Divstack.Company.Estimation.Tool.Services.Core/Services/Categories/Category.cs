using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Categories
{
    public sealed class Category
    {
        private Category(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        private Category()
        {
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public static Category Create(string name, string description)
        {
            return new Category(name, description);
        }
    }
}
