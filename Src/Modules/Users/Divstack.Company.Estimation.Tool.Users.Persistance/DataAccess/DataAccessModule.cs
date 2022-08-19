namespace Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Data;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        services.AddDbContext<UsersContext>(connectionString);

        return services;
    }

    private static void AddDbContext<TContext>(this IServiceCollection services, string connectionString)
        where TContext : DbContext
    {
        services.AddDbContextPool<TContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
        dbContext.Database.Migrate();
    }
}
