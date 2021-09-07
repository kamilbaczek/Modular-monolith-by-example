using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
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
            builder.OwnsMany<InquiryService>("InquiryServices", servicesBuilder =>
            {
                servicesBuilder.WithOwner("Enquiry").HasForeignKey();
                servicesBuilder.ToTable("InquiryServices");
                servicesBuilder.HasKey("Id");
                servicesBuilder.Property<ServiceId>("ServiceId")
                    .HasConversion(id => id.Value, value => new ServiceId(value))
                    .IsIdentity();
                    servicesBuilder.Property<InquiryServiceId>("Id")
                        .HasConversion(id => id.Value, value => new InquiryServiceId(value))
                        .IsIdentity();
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
        }
    }
}
