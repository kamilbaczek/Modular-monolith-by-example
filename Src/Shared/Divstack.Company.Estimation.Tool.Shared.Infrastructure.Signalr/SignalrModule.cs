using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Signalr;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class SignalrModule
{
    public static void UseSignalr(this IApplicationBuilder app)
    {
    }
    
    internal static IServiceCollection AddSignalr(this IServiceCollection services)
    {
        services.AddSignalR();
        return services;
    }
}
