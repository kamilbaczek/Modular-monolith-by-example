namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Configurations;

using Microsoft.Extensions.Configuration;

internal sealed class CorsConfiguration : ICorsConfiguration
{
    private const string Cors = "Cors";

    private readonly IConfigurationSection _configuration;
    public CorsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration.GetSection(Cors);
    }
    public string Origin => _configuration.GetValue<string>(nameof(Origin));
}
