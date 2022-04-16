namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Configuration;

using Azure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class AppConfigurationModule
{
    public static void AddApplicationConfiguration(this IConfigurationBuilder builder, IConfiguration configuration)
    {
        builder.AddAzureApplicationConfiguration(configuration);
    }

    internal static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddAzureApplicationConfiguration();

        return services;
    }
}
