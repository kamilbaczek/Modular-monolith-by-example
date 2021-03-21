using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Products.Categories
{
    internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Products");
            builder.HasKey(category => category.Id);
            builder.Property(product => product.Name).HasMaxLength(255).IsRequired();
        }
    }
}