namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;

using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddMarten(connectionString);

        return services;
    }


    internal static void UseDataAccess(this IApplicationBuilder app)
    {
    }
}
