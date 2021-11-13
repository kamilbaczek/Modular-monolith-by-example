namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using Abstractions.BackgroundProcessing;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    internal static IServiceCollection AddBackgroundProcessing(this IServiceCollection services)
    {
        services.AddHangfire(configuration => { configuration.UseInMemoryStorage(); });
        services.AddHangfireServer();
        services.AddScoped<IBackgroundJobScheduler, BackgroundJobScheduler>();
        services.AddScoped<IBackgroundProcessQueue, BackgroundProcessQueue>();

        return services;
    }

    internal static void UseBackgroundProcessing(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard();
    }
}
