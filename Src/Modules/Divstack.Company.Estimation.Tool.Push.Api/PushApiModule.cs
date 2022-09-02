[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]
namespace Divstack.Company.Estimation.Tool.Push.Api;

using Common.CurrentUser;
using Microsoft.Extensions.DependencyInjection;

internal static class PushApiModule
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
