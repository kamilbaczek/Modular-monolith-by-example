using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance
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
