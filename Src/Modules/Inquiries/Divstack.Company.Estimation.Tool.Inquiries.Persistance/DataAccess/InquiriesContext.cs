namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;

using Domain.Inquiries;
using Inquiries.Domain.Inquiries;
using Microsoft.EntityFrameworkCore;

public sealed class InquiriesContext : DbContext
{
    public InquiriesContext(DbContextOptions<InquiriesContext> options)
        : base(options)
    {
    }

    internal DbSet<Inquiry> Inquiries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InquiryEntityTypeConfiguration).Assembly);
    }
}
