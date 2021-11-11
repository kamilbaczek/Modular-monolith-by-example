using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance;

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

    internal static void UsePersistanceModule(this IApplicationBuilder app)
    {
        app.UseDataAccess();
    }
}
