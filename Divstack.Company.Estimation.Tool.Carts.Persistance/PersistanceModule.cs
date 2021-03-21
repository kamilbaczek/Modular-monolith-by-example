using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Carts.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Carts.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Carts.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Carts.Persistance
{
    internal static class PersistanceModule
    {
        private const string CartsConnectionString = "Carts";

        internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(CartsConnectionString);
            services.AddDataAccess(connectionString);
            services.AddRepositories();

            return services;
        }
    }
}
