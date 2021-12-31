namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance;

using System.Reflection;
using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class NotificationsApiModule
{
    public static IServiceCollection AddNotificationsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INotificationsContext, NotificationsContext>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName);
        services.AddDataAccess(connectionString);

        return services;
    }

    public static void UseNotifications(this IApplicationBuilder app)
    {
        NotificationPersistanceConfiguration.Configure();
    }
}
