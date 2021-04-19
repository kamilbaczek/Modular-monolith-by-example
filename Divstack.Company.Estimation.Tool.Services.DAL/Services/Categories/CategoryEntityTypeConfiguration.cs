using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Services.DAL.Services.Categories
{
    internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(category => category.Id);
            builder.Property(service => service.Name).HasMaxLength(255).IsRequired();
        }
    }
}