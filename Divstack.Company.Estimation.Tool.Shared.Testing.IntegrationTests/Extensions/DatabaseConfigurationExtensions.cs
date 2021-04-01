using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        private static void RemoveDbContextConfiguration<TDbContext>(this IServiceCollection serviceCollection) where TDbContext: DbContext
        {
            var descriptor = serviceCollection.SingleOrDefault(
                service => service.ServiceType == typeof(DbContextOptions<TDbContext>));

            if (descriptor is not null)
            {
                serviceCollection.Remove(descriptor);
            }
        }

        public static void ReplaceToInMemoryInstance<TDbContext>(this IServiceCollection serviceCollection) where TDbContext: DbContext
        {
            serviceCollection.RemoveDbContextConfiguration<TDbContext>();
            serviceCollection.AddDbContext<TDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameof(TDbContext));
            });
        }
    }
}
