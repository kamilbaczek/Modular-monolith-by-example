using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Carts.Persistance.DataAccess
{
    internal sealed class CartsContextFactory : DesignTimeDbContextFactoryBase<CartsContext>
    {
        protected override CartsContext CreateNewInstance(DbContextOptions<CartsContext> options)
        {
            return new CartsContext(options);
        }
    }
}