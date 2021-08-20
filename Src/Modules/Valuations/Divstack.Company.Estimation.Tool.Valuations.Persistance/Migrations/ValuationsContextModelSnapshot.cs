﻿// <auto-generated />
using System;
using Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Migrations
{
    [DbContext(typeof(ValuationsContext))]
    partial class ValuationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Valuation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CompletedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RequestedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Valuations");
                });

            modelBuilder.Entity("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Valuation", b =>
                {
                    b.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines.Deadline", "Deadline", b1 =>
                        {
                            b1.Property<Guid>("ValuationId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("ValuationId");

                            b1.ToTable("Valuations");

                            b1.WithOwner()
                                .HasForeignKey("ValuationId");
                        });

                    b.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries.Enquiry", "Enquiry", b1 =>
                        {
                            b1.Property<Guid>("ValuationId")
                                .HasColumnType("char(36)");

                            b1.HasKey("ValuationId");

                            b1.ToTable("Valuations");

                            b1.WithOwner()
                                .HasForeignKey("ValuationId");

                            b1.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients.Client", "Client", b2 =>
                                {
                                    b2.Property<Guid>("EnquiryValuationId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("FirstName")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.Property<string>("LastName")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.HasKey("EnquiryValuationId");

                                    b2.ToTable("Valuations");

                                    b2.WithOwner()
                                        .HasForeignKey("EnquiryValuationId");

                                    b2.OwnsOne("Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails.Email", "Email", b3 =>
                                        {
                                            b3.Property<Guid>("ClientEnquiryValuationId")
                                                .HasColumnType("char(36)");

                                            b3.Property<string>("Value")
                                                .IsRequired()
                                                .HasMaxLength(255)
                                                .HasColumnType("varchar(255)");

                                            b3.HasKey("ClientEnquiryValuationId");

                                            b3.ToTable("Valuations");

                                            b3.WithOwner()
                                                .HasForeignKey("ClientEnquiryValuationId");
                                        });

                                    b2.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients.ClientCompany", "Company", b3 =>
                                        {
                                            b3.Property<Guid>("ClientEnquiryValuationId")
                                                .HasColumnType("char(36)");

                                            b3.Property<string>("Name")
                                                .IsRequired()
                                                .HasColumnType("longtext");

                                            b3.Property<string>("Size")
                                                .IsRequired()
                                                .HasColumnType("longtext");

                                            b3.HasKey("ClientEnquiryValuationId");

                                            b3.ToTable("Valuations");

                                            b3.WithOwner()
                                                .HasForeignKey("ClientEnquiryValuationId");
                                        });

                                    b2.Navigation("Company");

                                    b2.Navigation("Email");
                                });

                            b1.OwnsMany("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries.InquiryService", "InquiryServices", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("EnquiryValuationId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid?>("ServiceId")
                                        .HasColumnType("char(36)");

                                    b2.HasKey("Id");

                                    b2.HasIndex("EnquiryValuationId");

                                    b2.ToTable("InquiryServices");

                                    b2.WithOwner("Enquiry")
                                        .HasForeignKey("EnquiryValuationId");

                                    b2.Navigation("Enquiry");
                                });

                            b1.Navigation("Client");

                            b1.Navigation("InquiryServices");
                        });

                    b.OwnsMany("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History.HistoricalEntry", "History", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("ChangeDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("ValuationId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("ValuationId");

                            b1.ToTable("ValuationsHistory");

                            b1.WithOwner("Valuation")
                                .HasForeignKey("ValuationId");

                            b1.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.ValuationStatus", "Status", b2 =>
                                {
                                    b2.Property<Guid>("HistoricalEntryId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.HasKey("HistoricalEntryId");

                                    b2.ToTable("ValuationsHistory");

                                    b2.WithOwner()
                                        .HasForeignKey("HistoricalEntryId");
                                });

                            b1.Navigation("Status");

                            b1.Navigation("Valuation");
                        });

                    b.OwnsMany("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Proposal", "Proposals", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime?>("Cancelled")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid?>("CancelledBy")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("Suggested")
                                .HasColumnType("datetime(6)");

                            b1.Property<Guid>("SuggestedBy")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("ValuationId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("ValuationId");

                            b1.ToTable("Proposals");

                            b1.WithOwner("Valuation")
                                .HasForeignKey("ValuationId");

                            b1.OwnsOne("Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Money", "Price", b2 =>
                                {
                                    b2.Property<Guid>("ProposalId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Currency")
                                        .HasColumnType("longtext");

                                    b2.Property<decimal?>("Value")
                                        .HasPrecision(15, 2)
                                        .HasColumnType("decimal(15,2)");

                                    b2.HasKey("ProposalId");

                                    b2.ToTable("Proposals");

                                    b2.WithOwner()
                                        .HasForeignKey("ProposalId");
                                });

                            b1.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.ProposalDecision", "Decision", b2 =>
                                {
                                    b2.Property<Guid>("ProposalId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasMaxLength(10)
                                        .HasColumnType("varchar(10)");

                                    b2.Property<DateTime?>("Date")
                                        .IsRequired()
                                        .HasColumnType("datetime(6)");

                                    b2.HasKey("ProposalId");

                                    b2.ToTable("Proposals");

                                    b2.WithOwner()
                                        .HasForeignKey("ProposalId");
                                });

                            b1.OwnsOne("Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.ProposalDescription", "Description", b2 =>
                                {
                                    b2.Property<Guid>("ProposalId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Message")
                                        .HasMaxLength(512)
                                        .HasColumnType("varchar(512)");

                                    b2.HasKey("ProposalId");

                                    b2.ToTable("Proposals");

                                    b2.WithOwner()
                                        .HasForeignKey("ProposalId");
                                });

                            b1.Navigation("Decision");

                            b1.Navigation("Description");

                            b1.Navigation("Price");

                            b1.Navigation("Valuation");
                        });

                    b.Navigation("Deadline");

                    b.Navigation("Enquiry");

                    b.Navigation("History");

                    b.Navigation("Proposals");
                });
#pragma warning restore 612, 618
        }
    }
}
