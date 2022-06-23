namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Services.Categories;

using Core.Services.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    private static readonly int MaxLength = 255;
    private static readonly string TableName = "CategoryEntityTypeConfiguration";

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(category => category.Id);
        builder.Property(service => service.Name).HasMaxLength(MaxLength).IsRequired();
    }
}
