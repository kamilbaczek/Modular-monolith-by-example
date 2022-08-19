[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Payments.Api;

using Common.UserAccess;
using Domain.Common.UserAccess;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Shared.Infrastructure.FeatureFlags;

internal static class PaymentsModule
{
    public static void AddPaymentsModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddInfrastructure(configuration);
    }

    public static void UsePaymentModule(this IApplicationBuilder app)
    {
        app.UseInfrastructure();
    }
}
