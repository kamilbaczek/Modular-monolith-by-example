[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Api;

using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

internal static class InquiriesModule
{
    public static IServiceCollection AddInquiriesModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        return services;
    }

    public static void UseInquiriesModule(this IApplicationBuilder app)
    {
        app.UseInfrastructure();
    }
}
