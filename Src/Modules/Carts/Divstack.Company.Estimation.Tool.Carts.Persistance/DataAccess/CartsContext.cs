using Divstack.Company.Estimation.Tool.Carts.Domain.Carts;
using Divstack.Company.Estimation.Tool.Carts.Persistance.Domain.Carts;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Carts.Persistance.DataAccess
{
    internal class CartsContext : DbContext
    {
        public CartsContext(DbContextOptions<CartsContext> options)
            : base(options)
        {
        }

        internal DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CartEntityTypeConfiguration).Assembly);
        }
    }
}