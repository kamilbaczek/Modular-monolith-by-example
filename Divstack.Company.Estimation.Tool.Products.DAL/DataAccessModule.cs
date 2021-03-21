using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Products.Core;
using Divstack.Company.Estimation.Tool.Products.DAL.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Products.Api")]
namespace Divstack.Company.Estimation.Tool.Products.DAL
{
    internal static class DataAccessModule
    {
        private const string ProductsConnectionString = "Products";

        internal static IServiceCollection AddDataAccess(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddCore();
            services.RegisterRepositories();

            var connectionString = configuration.GetConnectionString(ProductsConnectionString);
            services.AddDbContext<ProductsContext>(connectionString);

            return services;
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<ProductsRepository>()
                .AddClasses(c => c.Where(@class => @class.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
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
