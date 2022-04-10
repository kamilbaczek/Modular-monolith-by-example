using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Configuration;

using Exception;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

internal static class AzureAppConfigurationModule
{
    private const string LabelFilter = "dev";
    private const string Environment = "ASPNETCORE_ENVIRONMENT";
    private const string AzureAppConfiguration = "AzureAppConfiguration";

    internal static void AddAzureApplicationConfiguration(this IConfigurationBuilder builder, IConfiguration configuration)
    {
        var environment = System.Environment.GetEnvironmentVariable(Environment);
        if (string.IsNullOrEmpty(environment))
            throw new EnvironmentNameNotFoundException();

        var connectionString = configuration.GetConnectionString(AzureAppConfiguration);
        builder.AddAzureAppConfiguration(options =>
        {
            options.Connect(connectionString);
            options.Select(KeyFilter.Any, LabelFilter);
            options.ConfigureRefresh(refresh =>
            {
                refresh.Register(KeyFilter.Any, refreshAll: true);
            });
        });
    }
}
