using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Configuration;

using Exception;
using global::Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

internal static class AzureAppConfigurationModule
{
    private const string Environment = "ASPNETCORE_ENVIRONMENT";
    private const string AzureAppConfiguration = "ConnectionStrings__AzureAppConfiguration";

    internal static void AddAzureApplicationConfiguration(this IConfigurationBuilder builder, IConfiguration configuration)
    {
        var connectionString = System.Environment.GetEnvironmentVariable(AzureAppConfiguration);
        var azureApplicationConfigurationEnabled = !string.IsNullOrEmpty(connectionString);
        if(!azureApplicationConfigurationEnabled)
            return;

        var environment = System.Environment.GetEnvironmentVariable(Environment);
        if (string.IsNullOrEmpty(environment))
            throw new EnvironmentNameNotFoundException();

        builder.AddAzureAppConfiguration(options =>
        {
            options.Connect(connectionString);
            options.Select(KeyFilter.Any, environment);
            options.ConfigureRefresh(refresh =>
            {
                refresh.Register(KeyFilter.Any, true);
            });
            options.ConfigureKeyVault(keyVaultOptions =>
            {
                var credential = new DefaultAzureCredential();
                keyVaultOptions.SetCredential(credential);
            });
            options.UseFeatureFlags();
        });
    }
}
