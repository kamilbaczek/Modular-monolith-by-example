namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello.Configuration
{
    internal interface ITrelloConfiguration
    {
        string BoardId { get; }
        string AppKey { get; }
        string UserToken { get; }
    }
}