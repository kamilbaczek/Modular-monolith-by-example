using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Services.DAL
{
    internal sealed class ServicesContextFactory : DesignTimeDbContextFactoryBase<ServicesContext>
    {
        protected override ServicesContext CreateNewInstance(DbContextOptions<ServicesContext> options)
        {
            return new ServicesContext(options);
        }
    }
}