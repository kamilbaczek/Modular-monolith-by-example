namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.WebSockets;

using Configurations;
using Microsoft.AspNetCore.Builder;

internal static class WebSocketsExtensions
{
    internal static void UseWebSockets(this IApplicationBuilder app, IConfiguration configuration)
    {
        var webSocketsConfiguration = new WebSocketsConfiguration(configuration);
        var webSocketOptions = new WebSocketOptions();
        webSocketOptions.AllowedOrigins.Add(webSocketsConfiguration.AllowedOrigin);

        app.UseWebSockets(webSocketOptions);
    }
}
