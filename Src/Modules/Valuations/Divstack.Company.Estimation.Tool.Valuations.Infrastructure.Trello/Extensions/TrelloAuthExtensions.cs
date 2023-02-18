namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Extensions;

using Configuration;
using Manatee.Trello;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TrelloConfiguration = Manatee.Trello.TrelloConfiguration;

internal static class TrelloAuthExtensions
{
    internal static void UseTrelloAuthentication(this IApplicationBuilder app)
    {
        var serviceProvider = app.ApplicationServices;
        var trelloConfiguration = serviceProvider.GetRequiredService<ITrelloConfiguration>();

        TrelloAuthorization.Default.AppKey = trelloConfiguration.AppKey;
        TrelloAuthorization.Default.UserToken = trelloConfiguration.UserToken;
    }
}
