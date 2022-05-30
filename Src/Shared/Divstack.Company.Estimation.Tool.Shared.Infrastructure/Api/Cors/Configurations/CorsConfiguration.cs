namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Cors.Configurations;

using Ardalis.GuardClauses;

internal sealed class CorsConfiguration : ICorsConfiguration
{
    private const string Cors = "Cors";

    private readonly IConfigurationSection _configuration;
    internal CorsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration.GetSection(Cors);
    }
    public string Origin => Guard.Against.NullOrEmpty(nameof(Origin), nameof(Origin));
}
