namespace Divstack.Company.Estimation.Tool.Services.DAL.Services.Categories;

using Core.Services.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(category => category.Id);
        builder.Property(service => service.Name).HasMaxLength(255).IsRequired();
    }
}
