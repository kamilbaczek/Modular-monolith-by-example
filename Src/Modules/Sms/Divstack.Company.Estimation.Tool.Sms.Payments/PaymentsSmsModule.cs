using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Sms")]

namespace Divstack.Estimation.Tool.Sms.Payments;

using Microsoft.Extensions.DependencyInjection;

internal static class PaymentsSmsModule
{
    internal static IServiceCollection AddPayments(this IServiceCollection services)
    {
        return services;
    }
}
