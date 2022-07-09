[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Inquiries.Api;

using Infrastructure;
using Microsoft.Extensions.Configuration;
using Shared.Infrastructure.FeatureFlags;

internal static class InquiriesModule
{
    public static void AddInquiriesModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddInfrastructure(configuration);
    }
}
