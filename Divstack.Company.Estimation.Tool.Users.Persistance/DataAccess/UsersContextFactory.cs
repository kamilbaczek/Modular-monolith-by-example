using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess
{
    internal sealed class UsersContextFactory : DesignTimeDbContextFactoryBase<UsersContext>
    {
        protected override UsersContext CreateNewInstance(DbContextOptions<UsersContext> options)
        {
            return new UsersContext(options);
        }
    }
}