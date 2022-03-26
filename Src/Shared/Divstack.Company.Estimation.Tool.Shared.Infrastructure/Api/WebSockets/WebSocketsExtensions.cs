namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.WebSockets;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

internal static class WebSocketsExtensions
{
    internal static void UseWebSockets(this IApplicationBuilder app, IConfiguration configuration)
    {
        var wsOptions = new WebSocketOptions();
        wsOptions.AllowedOrigins.Add("http://localhost:8080");
        wsOptions.AllowedOrigins.Add("http://localhost");
        app.UseWebSockets(wsOptions);
    }
}
