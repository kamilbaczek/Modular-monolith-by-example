using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Estimations.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Estimations.Persistance
{
    internal static class PersistanceModule
    {
        internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName);
            services.AddDataAccess(connectionString);
            services.AddRepositories();

            return services;
        }
    }
}
