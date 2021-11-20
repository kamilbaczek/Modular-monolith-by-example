[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Payments.Api;

using Common.UserAccess;
using Domain.Common.UserAccess;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

internal static class PaymentsModule
{
    public static IServiceCollection AddPaymentsModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddInfrastructure(configuration);

        return services;
    }

    public static void UsePaymentModule(this IApplicationBuilder app)
    {
        app.UseInfrastructure();
    }
}
