namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using Abstractions.BackgroundProcessing;
using Dashboard;
using Hangfire;
using Microsoft.AspNetCore.Builder;

internal static class Extensions
{
    private const string BackgroundProcessingPath = "/background-processing";

    internal static IServiceCollection AddBackgroundProcessing(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(hangfireConfiguration =>
        {
            hangfireConfiguration.UseInMemoryStorage();
        });
        services.AddHangfireServer();

        services.AddScoped<IBackgroundJobScheduler, BackgroundJobScheduler>();
        services.AddScoped<IBackgroundProcessQueue, BackgroundProcessQueue>();
        services.AddScoped<IRecurringBackgroundJobScheduler, RecurringBackgroundJobScheduler>();

        return services;
    }

    internal static void UseBackgroundProcessing(this IApplicationBuilder app)
    {
        var dashboardOptions =
            new DashboardOptions
            {
                Authorization = new[]
                {
                    new DashboardAuthorizationFilter()
                },
                AsyncAuthorization = new[]
                {
                    new DashboardAuthorizationFilter()
                },
            };
        app.UseHangfireDashboard(BackgroundProcessingPath, dashboardOptions);
    }
}
