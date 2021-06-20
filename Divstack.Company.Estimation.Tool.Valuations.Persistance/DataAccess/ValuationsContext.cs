using Divstack.Company.Estimation.Tool.Estimations.Persistance.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Microsoft.EntityFrameworkCore;


namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess
{
    public sealed class ValuationsContext : DbContext
    {
        public ValuationsContext(DbContextOptions<ValuationsContext> options)
            : base(options)
        {
        }

        internal DbSet<Valuation> Valuations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Valuations");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValuationEntityTypeConfiguration).Assembly);
        }
    }
}
