using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance.Domain.Inquiries;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess
{
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
}
