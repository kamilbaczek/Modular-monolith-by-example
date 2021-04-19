using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Services.DAL.Services
{
    internal class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(service => service.Id);
            builder.HasOne(service => service.Category)
                .WithMany();
            builder.Property(service => service.Name).HasMaxLength(255).IsRequired();
            builder.Property(service => service.Description).HasMaxLength(512).IsRequired();
            builder.Property(service => service.CreatedBy).IsRequired();
            builder.OwnsMany<Attribute>("Attributes", ownedAttribute =>
            {
                ownedAttribute.ToTable("Attributes");
                ownedAttribute.HasKey("Id");
                ownedAttribute.WithOwner("Service").HasForeignKey();
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