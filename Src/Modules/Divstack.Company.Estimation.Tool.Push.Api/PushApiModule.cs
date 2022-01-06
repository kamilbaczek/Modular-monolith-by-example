using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Api;

using Microsoft.Extensions.DependencyInjection;

internal static class PushApiModule
{
    public static IServiceCollection AddPushNotificationsApi(this IServiceCollection services)
    {
        return services;
    }
}
