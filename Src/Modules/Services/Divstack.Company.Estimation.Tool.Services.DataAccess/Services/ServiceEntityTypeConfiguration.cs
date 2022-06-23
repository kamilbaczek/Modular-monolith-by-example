namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Services;

using Core.Services;
using Core.Services.Attributes;
using Core.Services.Attributes.PossibleValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
{
    private static readonly int MaxLength = 255;
    private static readonly int MaxLengthLongField = 512;
    private static readonly string Services = "Services";
    private static readonly string Attributes = "Attributes";
    private static readonly string AttributePossibleValues = "AttributePossibleValues";
    private static readonly string PossibleValues = "PossibleValues";

    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable(Services);
        builder.HasKey(service => service.Id);
        builder.HasOne(service => service.Category)
            .WithMany();
        builder.Property(service => service.Name).HasMaxLength(MaxLength).IsRequired();
        builder.Property(service => service.Description).HasMaxLength(MaxLengthLongField).IsRequired();
        builder.Property(service => service.CreatedBy).IsRequired();
        builder.OwnsMany<Attribute>(Attributes, ownedAttribute =>
        {
            ownedAttribute.ToTable(Attributes);
            ownedAttribute.HasKey("Id");
            ownedAttribute.WithOwner("Service").HasForeignKey();
            ownedAttribute.Property<string>("Name").HasMaxLength(MaxLength).IsRequired();
            ownedAttribute.OwnsMany<PossibleValue>(PossibleValues,
                ownedPotentialValues =>
                {
                    ownedAttribute.ToTable(AttributePossibleValues);
                    ownedPotentialValues.WithOwner("Attribute").HasForeignKey();
                    ownedPotentialValues.HasKey("Id");
                    ownedPotentialValues.Property<string>("Value").HasMaxLength(MaxLength).IsRequired();
                });
        });
    }
}
