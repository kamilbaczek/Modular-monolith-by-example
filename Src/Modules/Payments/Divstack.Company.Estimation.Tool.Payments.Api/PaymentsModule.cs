using Divstack.Company.Estimation.Tool.Payments.Api.Common.UserAccess;
using Divstack.Company.Estimation.Tool.Payments.Domain.Common.UserAccess;
using Divstack.Company.Estimation.Tool.Payments.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Payments.Api;

internal static class PaymentsModule
{
    public static IServiceCollection AddPaymentModule(this IServiceCollection services,
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
