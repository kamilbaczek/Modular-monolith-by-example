using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder
{
    public interface IUsersSeeder
    {
        Task SeedAdminUserAsync();
    }
}