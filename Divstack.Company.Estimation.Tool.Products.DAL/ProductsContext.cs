using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.DAL.Products;
using Microsoft.EntityFrameworkCore;

[assembly:InternalsVisibleTo("Divstack.Company.Estimation.Tool.Products.IntegrationsTests")]
namespace Divstack.Company.Estimation.Tool.Products.DAL
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options)
            : base(options)
        {
        }

        internal DbSet<Product> Products { get; set; }
        internal DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
        }
    }
}
