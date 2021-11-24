namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;

using Microsoft.Extensions.DependencyInjection;

internal static class UsersSeederModule
{
    internal static void AddUserSeeder(this IServiceCollection services)
    {
        services.AddTransient<IUsersSeeder, UsersSeeder>();
        services.AddHostedService<UsersSeederInitializer>();
    }
}
