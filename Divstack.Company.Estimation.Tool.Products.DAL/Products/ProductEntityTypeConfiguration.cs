using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Products
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Products");
            builder.HasKey(product => product.Id);
            builder.HasOne(product => product.Category)
                .WithMany();
            builder.Property(product => product.Name).HasMaxLength(255).IsRequired();
            builder.Property(product => product.Description).HasMaxLength(512).IsRequired();
            builder.Property(product => product.CreatedBy).IsRequired();
        }
    }
}
