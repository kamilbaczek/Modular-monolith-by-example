using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Sms")]
namespace Divstack.Estimation.Tool.Sms.Valuations;

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

internal static class ValuationsSmsModule
{
    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
