using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Configuration;
using Manatee.Trello;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.Extensions
{
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
}