using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Products.DAL
{
    internal sealed class ProductsContextFactory : DesignTimeDbContextFactoryBase<ProductsContext>
    {
        protected override ProductsContext CreateNewInstance(DbContextOptions<ProductsContext> options)
        {
            return new ProductsContext(options);
        }
    }
}
