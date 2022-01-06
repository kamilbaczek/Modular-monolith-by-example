namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Configurations;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class CorsConfiguration : ICorsConfiguration
{
    private const string Cors = "Cors";

    private readonly IConfigurationSection _configuration;
    internal CorsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration.GetSection(Cors);
    }
    public string Origin => Guard.Against.NullOrEmpty(_configuration.GetValue<string>(nameof(Origin)), nameof(Origin));
}
