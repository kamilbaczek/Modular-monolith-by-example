using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Estimations.Persistance.Domain.Valuations;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess
{
    public class ValuationsContext : DbContext
    {
        public ValuationsContext(DbContextOptions<ValuationsContext> options)
            : base(options)
        {
        }

        internal DbSet<Valuation> Valuations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValuationEntityTypeConfiguration).Assembly);
        }
    }
}
