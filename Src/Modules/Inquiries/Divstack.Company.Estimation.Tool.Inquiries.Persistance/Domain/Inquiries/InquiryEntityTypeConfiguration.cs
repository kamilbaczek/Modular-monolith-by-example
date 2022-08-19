namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Domain.Inquiries;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.DDD.ValueObjects.Emails;
using Shared.DDD.ValueObjects.PhoneNumbers;
using Tool.Inquiries.Domain.Inquiries;
using Tool.Inquiries.Domain.Inquiries.Clients;
using Tool.Inquiries.Domain.Inquiries.Items;
using Tool.Inquiries.Domain.Inquiries.Items.Services;
using Tool.Inquiries.Domain.Inquiries.Items.Services.Attributes;

internal class InquiryEntityTypeConfiguration : IEntityTypeConfiguration<Inquiry>
{
    public void Configure(EntityTypeBuilder<Inquiry> builder)
    {
        builder.ToTable("Inquiries");
        builder.HasKey("Id");
        builder.Property<InquiryId>("Id")
            .HasConversion(id => id.Value, value => new InquiryId(value));
        builder.OwnsMany<InquiryItem>("InquiryItems", inquiryServiceBuilder =>
        {
            inquiryServiceBuilder.WithOwner("Inquiry").HasForeignKey();
            inquiryServiceBuilder.ToTable("InquiryItems");
            inquiryServiceBuilder.HasKey("Id");
            inquiryServiceBuilder.Property<InquiryItemId>("Id")
                .HasConversion(id => id.Value, value => new InquiryItemId(value));
            inquiryServiceBuilder.OwnsOne<Service>("Service", servicesBuilder =>
            {
                inquiryServiceBuilder.ToTable("InquiryItemsServices");
                servicesBuilder.Property<ServiceId>("ServiceId")
                    .HasConversion(id => id.Value, value => new ServiceId(value));
                servicesBuilder.OwnsMany<Attribute>("Attributes", attributeBuilder =>
                {
                    attributeBuilder.ToTable("InquiryItemsServicesAttributes");
                    attributeBuilder.HasKey("Id");
                    attributeBuilder.Property<AttributeId>("Id")
                        .HasConversion(id => id.Value, value => new AttributeId(value));
                    attributeBuilder.Property<AttributeValueId>("ValueId")
                        .HasConversion(id => id.Value, value => new AttributeValueId(value));
                    attributeBuilder.WithOwner("Service").HasForeignKey();
                });
            });
            builder.OwnsOne<Client>("Client", clientValueObjectBuilder =>
            {
                clientValueObjectBuilder.Property<string>("FirstName").IsRequired();
                clientValueObjectBuilder.Property<string>("LastName").IsRequired();
                clientValueObjectBuilder.OwnsOne<Email>("Email",
                    emailValueObjectBuilder =>
                    {
                        emailValueObjectBuilder.Property<string>("Value").IsRequired().HasMaxLength(255);
                    });
                clientValueObjectBuilder.OwnsOne<PhoneNumber>("PhoneNumber",
                    phoneNumberValueObjectBuilder =>
                    {
                        phoneNumberValueObjectBuilder.Property<string>("Value").IsRequired().HasMaxLength(13);
                    });
                clientValueObjectBuilder.OwnsOne<ClientCompany>("Company", clientCompanyValueObjectBuilder =>
                {
                    clientCompanyValueObjectBuilder.Property<string>("Size").IsRequired();
                    clientCompanyValueObjectBuilder.Property<string>("Name").IsRequired();
                });
            });
        });
    }
}
