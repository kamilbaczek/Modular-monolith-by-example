using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder
{
    internal sealed class UsersSeederInitializer : IHostedService
    {
        private readonly IUsersSeeder _usersSeeder;

        public UsersSeederInitializer(IUsersSeeder usersSeeder)
        {
            _usersSeeder = usersSeeder;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
           await _usersSeeder.SeedAdminUserAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
