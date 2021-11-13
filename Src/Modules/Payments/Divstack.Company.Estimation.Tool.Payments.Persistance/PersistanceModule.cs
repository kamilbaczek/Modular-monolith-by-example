using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Payments.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Payments.Persistance;

using Domain.Payments.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class PersistanceModule
{
    internal static IServiceCollection AddPersistanceModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRepositories();

        return services;
    }

    internal static void UsePersistanceModule(this IApplicationBuilder app)
    {
    }
}
