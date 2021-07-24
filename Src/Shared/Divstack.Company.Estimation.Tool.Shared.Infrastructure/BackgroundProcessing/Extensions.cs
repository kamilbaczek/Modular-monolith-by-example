using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing
{
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
}
