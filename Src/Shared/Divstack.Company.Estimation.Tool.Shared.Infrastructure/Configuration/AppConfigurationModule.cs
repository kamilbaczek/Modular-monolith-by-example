namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Configuration;

using Azure.Configuration;

internal static class AppConfigurationModule
{
    public static void AddApplicationConfiguration(this IConfigurationBuilder builder, IConfiguration configuration) => builder.AddAzureApplicationConfiguration(configuration);
}
