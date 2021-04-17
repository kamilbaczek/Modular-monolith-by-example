using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Products.DAL.Products
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(product => product.Id);
            builder.HasOne(product => product.Category)
                .WithMany();
            builder.Property(product => product.Name).HasMaxLength(255).IsRequired();
            builder.Property(product => product.Description).HasMaxLength(512).IsRequired();
            builder.Property(product => product.CreatedBy).IsRequired();
            builder.OwnsMany<Attribute>("Attributes", ownedAttribute =>
            {
                ownedAttribute.ToTable("Attributes");
                ownedAttribute.HasKey("Id");
                ownedAttribute.WithOwner("Product").HasForeignKey();
                ownedAttribute.Property<string>("Name").HasMaxLength(255).IsRequired();
                ownedAttribute.OwnsMany<PossibleValue>("PossibleValues",
                    ownedPotentialValues =>
                {
                    ownedAttribute.ToTable("AttributePossibleValues");
                    ownedPotentialValues.WithOwner("Attribute").HasForeignKey();
                    ownedPotentialValues.HasKey("Id");
                    ownedPotentialValues.Property<string>("Value").HasMaxLength(255).IsRequired();
                });
            });
        }
    }
}
