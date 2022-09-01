namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using Abstractions.BackgroundProcessing;
using Dashboard;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

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

    internal static IEndpointRouteBuilder MapBackgroundProcessing(
        this IEndpointRouteBuilder endpoints)
    {
        var dashboardOptions =
            new DashboardOptions
            {
                Authorization = new[]
                {
                    new DashboardAuthorizationFilter()
                }
            };
        endpoints.MapHangfireDashboard(BackgroundProcessingPath, dashboardOptions);

        return endpoints;
    }
}
