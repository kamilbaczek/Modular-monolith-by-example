using Divstack.Company.Estimation.Tool.Products.Core.Products;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories;
using Divstack.Company.Estimation.Tool.Products.DAL.Products;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Products.DAL
{
    public sealed class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
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
