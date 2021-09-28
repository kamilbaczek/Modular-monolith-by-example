using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services.Attributes;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Mysql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Domain.Inquiries
{
    internal class InquiryEntityTypeConfiguration : IEntityTypeConfiguration<Inquiry>
    {
        public void Configure(EntityTypeBuilder<Inquiry> builder)
        {
            builder.ToTable("Inquiries");
            builder.HasKey("Id");
            builder.Property<InquiryId>("Id")
                .HasConversion(id => id.Value, value => new InquiryId(value))
                .IsIdentity();
            builder.OwnsMany<InquiryItem>("InquiryItems", inquiryServiceBuilder =>
            {
                inquiryServiceBuilder.WithOwner("Inquiry").HasForeignKey();
                inquiryServiceBuilder.ToTable("InquiryItems");
                inquiryServiceBuilder.HasKey("Id");
                inquiryServiceBuilder.Property<InquiryItemId>("Id")
                    .HasConversion(id => id.Value, value => new InquiryItemId(value))
                    .IsIdentity();
                inquiryServiceBuilder.OwnsOne<Service>("Service", servicesBuilder =>
                {
                    inquiryServiceBuilder.ToTable("InquiryItemsServices");
                    servicesBuilder.Property<ServiceId>("ServiceId")
                        .HasConversion(id => id.Value, value => new ServiceId(value))
                        .IsIdentity();
                    servicesBuilder.OwnsMany<Attribute>("Attributes", attributeBuilder =>
                    {
                        attributeBuilder.ToTable("InquiryItemsServicesAttributes");
                        attributeBuilder.HasKey("Id");
                        attributeBuilder.Property<AttributeId>("Id")
                            .HasConversion(id => id.Value, value => new AttributeId(value))
                            .IsIdentity();
                        attributeBuilder.Property<AttributeValueId>("ValueId")
                            .HasConversion(id => id.Value, value => new AttributeValueId(value))
                            .IsIdentity();
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
                    clientValueObjectBuilder.OwnsOne<ClientCompany>("Company", clientCompanyValueObjectBuilder =>
                    {
                        clientCompanyValueObjectBuilder.Property<string>("Size").IsRequired();
                        clientCompanyValueObjectBuilder.Property<string>("Name").IsRequired();
                    });
                });
            });
        }
    }
}