namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using Abstractions.BackgroundProcessing;
using Dashboard;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;

internal static class Extensions
{
    private const string BackgroundProcessing = "/background-processing";

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
        var environment = app.ApplicationServices.GetRequiredService<IHostEnvironment>();
        var dashboardOptions =
            new DashboardOptions
            {
                Authorization = new[]
                {
                    new DashboardAuthorizationFilter(environment)
                },
                IsReadOnlyFunc = _ => true
            };
        app.UseHangfireDashboard(BackgroundProcessing, dashboardOptions);
    }

    internal static IEndpointRouteBuilder MapBackgroundProcessing(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHangfireDashboard();

        return endpoints;
    }
}
