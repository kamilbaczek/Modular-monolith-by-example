namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class TrelloConfiguration : ITrelloConfiguration
{
    private static readonly string BoardIdKeyName = $"Integrations:Trello:{nameof(BoardId)}";
    private static readonly string AppKeyKeyName = $"Integrations:Trello:{nameof(AppKey)}";
    private static readonly string UserTokenKeyName = $"Integrations:Trello:{nameof(UserToken)}";
    private readonly IConfiguration _configuration;

    public TrelloConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string BoardId => _configuration[BoardIdKeyName];
    public string AppKey => _configuration[AppKeyKeyName];
    public string UserToken => _configuration[UserTokenKeyName];
}
