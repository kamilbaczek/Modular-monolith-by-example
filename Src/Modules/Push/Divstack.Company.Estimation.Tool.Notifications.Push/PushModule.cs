namespace Divstack.Company.Estimation.Tool.Notifications.Push;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tool.Push.Valuations;

public static class PushModule
{
    public static IServiceCollection AddPushNotificationsModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSignalR();
        services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
        services.AddPushValuations(configuration);

        return services;
    }

    public static void UsePushNotificationsModule(this IApplicationBuilder app)
    {
        app.UsePushValuations();
    }
}
