using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder
{
    internal static class UsersSeederModule
    {
        internal static void AddUserSeeder(this IServiceCollection services)
        {
            services.AddTransient<IUsersSeeder, UsersSeeder>();
            services.AddHostedService<UsersSeederInitializer>();
        }
    }
}
