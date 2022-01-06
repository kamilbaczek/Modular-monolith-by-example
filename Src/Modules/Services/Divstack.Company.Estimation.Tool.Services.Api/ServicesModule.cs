using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Services.Api;

using Core.UserAccess;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAccess;

public static class ServicesModule
{
    public static IServiceCollection AddServicesModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
