using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess
{
    internal static class DataAccessModule
    {
        internal static IServiceCollection AddDataAccess(this IServiceCollection services,
            string connectionString)
        {
            services.AddSingleton<ISqlConnectionFactory>(provider => new SqlConnectionFactory(connectionString));

            services.AddDbContext<UsersContext>(connectionString);
            return services;
        }

        private static void AddDbContext<TContext>(this IServiceCollection services, string connectionString)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                options.UseSqlServer(connectionString)
            );

            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
            dbContext.Database.Migrate();
        }
    }
}