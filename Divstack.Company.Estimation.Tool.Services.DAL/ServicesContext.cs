using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Divstack.Company.Estimation.Tool.Services.DAL.Services;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Services.DAL
{
    public sealed class ServicesContext : DbContext
    {
        public ServicesContext(DbContextOptions<ServicesContext> options)
            : base(options)
        {
        }

        internal DbSet<Service> Services { get; set; }
        internal DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Services");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceEntityTypeConfiguration).Assembly);
        }
    }
}