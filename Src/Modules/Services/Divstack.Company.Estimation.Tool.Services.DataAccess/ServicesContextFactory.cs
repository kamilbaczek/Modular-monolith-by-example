namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using Microsoft.EntityFrameworkCore;

internal sealed class ServicesContextFactory : DesignTimeDbContextFactoryBase<ServicesContext>
{
    protected override ServicesContext CreateNewInstance(DbContextOptions<ServicesContext> options)
    {
        return new ServicesContext(options);
    }
}
