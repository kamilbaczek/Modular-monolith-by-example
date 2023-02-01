namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.WebSockets.Configurations;

using Ardalis.GuardClauses;

internal sealed class WebSocketsConfiguration : IWebSocketsConfiguration
{
    private const string WebSockets = "WebSockets";

    private readonly IConfigurationSection _configuration;

    internal WebSocketsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration.GetSection(nameof(WebSockets));
    }

    public string AllowedOrigin => Guard.Against.Null(_configuration.GetValue<string>(nameof(AllowedOrigin)))!;
}
