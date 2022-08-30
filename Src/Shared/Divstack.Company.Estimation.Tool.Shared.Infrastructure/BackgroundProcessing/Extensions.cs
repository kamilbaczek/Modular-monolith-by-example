namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using Abstractions.BackgroundProcessing;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Storage;

internal static class Extensions
{
    internal static IServiceCollection AddBackgroundProcessing(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(hangfireConfiguration => hangfireConfiguration.UseInMemoryStorage());
        services.AddHangfireServer();

        services.AddScoped<IBackgroundJobScheduler, BackgroundJobScheduler>();
        services.AddScoped<IBackgroundProcessQueue, BackgroundProcessQueue>();
        services.AddScoped<IRecurringBackgroundJobScheduler, RecurringBackgroundJobScheduler>();

        return services;
    }

    internal static void UseBackgroundProcessing(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard();
    }
}
