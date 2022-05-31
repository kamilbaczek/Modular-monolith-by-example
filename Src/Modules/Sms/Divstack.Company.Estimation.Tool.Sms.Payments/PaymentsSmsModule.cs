using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Sms")]

namespace Divstack.Estimation.Tool.Sms.Payments;

using Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish.Extensions;
using Microsoft.Extensions.DependencyInjection;

internal static class PaymentsSmsModule
{
    internal static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddIntegrationEventsHandlers(typeof(PaymentsSmsModule));

        return services;
    }
}
