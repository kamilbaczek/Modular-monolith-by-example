using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Sms")]

namespace Divstack.Estimation.Tool.Sms.Valuations;

using Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish.Extensions;
using Microsoft.Extensions.DependencyInjection;

internal static class ValuationsSmsModule
{
    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddIntegrationEventsHandlers(typeof(ValuationsSmsModule));

        return services;
    }
}
