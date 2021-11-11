using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;

internal sealed class UsersSeederInitializer : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UsersSeederInitializer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var serviceScope = _serviceScopeFactory.CreateScope();
        var usersSeeder = serviceScope.ServiceProvider.GetRequiredService<IUsersSeeder>();

        await usersSeeder.SeedAdminUserAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
