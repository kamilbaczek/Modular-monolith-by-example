using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Domain.Valuations
{
    internal class ValuationEntityTypeConfiguration : IEntityTypeConfiguration<Valuation>
    {
        public void Configure(EntityTypeBuilder<Valuation> builder)
        {
            builder.ToTable("Valuations");
            builder.HasKey("Id");
            builder.Property<ValuationId>("Id")
                .HasConversion(id => id.Value, value => new ValuationId(value));

            builder.OwnsMany<Proposal>("Proposals", ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.WithOwner("Valuation").HasForeignKey();
                ownedNavigationBuilder.ToTable("Proposals");
                ownedNavigationBuilder.HasKey("Id");
                ownedNavigationBuilder.Property<ProposalId>("Id")
                    .HasConversion(id => id.Value, value => new ProposalId(value));
                ownedNavigationBuilder.OwnsOne<Money>("Price", moneyValueObjectBuilder =>
                {
                    moneyValueObjectBuilder.Property<decimal?>("Value").IsRequired(false).HasPrecision(15, 2);
                    moneyValueObjectBuilder.Property<string>("Currency");
                });
                ownedNavigationBuilder.OwnsOne<ProposalDescription>("Description",
                    valueObjectBuilder => { valueObjectBuilder.Property<string>("Message").HasMaxLength(512); });
                ownedNavigationBuilder.Property<EmployeeId>("SuggestedBy")
                    .HasConversion(id => id.Value, value => new EmployeeId(value))
                    .IsRequired();
                ownedNavigationBuilder.Property<DateTime>("Suggested")
                    .IsRequired();
                ownedNavigationBuilder.Property<EmployeeId>("CancelledBy")
                    .HasConversion(id => id.Value, value => new EmployeeId(value))
                    .IsRequired(false);
                ownedNavigationBuilder.Property<DateTime?>("Cancelled")
                    .IsRequired(false);
                ownedNavigationBuilder.Property<bool>("IsWaitingForDecision")
                    .IsRequired();

                ownedNavigationBuilder.OwnsOne<ProposalDecision>("Decision", decisionValueObjectBuilder =>
                {
                    decisionValueObjectBuilder.Property<DateTime?>("Date").IsRequired();
                    decisionValueObjectBuilder.Property<string>("Code").IsRequired().HasMaxLength(10);
                    decisionValueObjectBuilder.Property<string>("RejectReason").IsRequired(false);
                });
            });
            builder.Property<DateTime>("RequestedDate").IsRequired();
            builder.Property<EmployeeId>("CompletedBy")
                .HasConversion(id => id.Value, value => new EmployeeId(value))
                .IsRequired(false);
            builder.Property<DateTime?>("CompletedDate").IsRequired(false);

            builder.OwnsOne<Enquiry>("Enquiry", enquiryValueObjectBuilder =>
            {
                enquiryValueObjectBuilder.OwnsMany<InquiryService>("InquiryServices", servicesBuilder =>
                {
                    servicesBuilder.WithOwner("Enquiry").HasForeignKey();
                    servicesBuilder.ToTable("InquiryServices");
                    servicesBuilder.HasKey("Id");
                    servicesBuilder.Property<ServiceId>("ServiceId")
                        .HasConversion(id => id.Value, value => new ServiceId(value));
                    servicesBuilder.Property<InquiryServiceId>("Id")
                        .HasConversion(id => id.Value, value => new InquiryServiceId(value));
                });
                enquiryValueObjectBuilder.OwnsOne<Client>("Client", clientValueObjectBuilder =>
                {
                    clientValueObjectBuilder.Property<string>("FirstName").IsRequired();
                    clientValueObjectBuilder.Property<string>("LastName").IsRequired();
                    clientValueObjectBuilder.OwnsOne<Email>("Email",
                        emailValueObjectBuilder =>
                        {
                            emailValueObjectBuilder.Property<string>("Value").IsRequired().HasMaxLength(255);
                        });
                    clientValueObjectBuilder.OwnsOne<Email>("Email",
                        emailValueObjectBuilder =>
                        {
                            emailValueObjectBuilder.Property<string>("Value").IsRequired().HasMaxLength(255);
                        });
                });
            });
        }
    }
}
