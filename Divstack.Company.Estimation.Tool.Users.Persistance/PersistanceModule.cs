using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Users.Persistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Users.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Users.Persistance
{
    internal static class PersistanceModule
    {
        private const string UsersConnectionString = "Users";

        internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(UsersConnectionString);
            services.AddDataAccess(connectionString);
            services.AddRepositories();

            return services;
        }
    }
}