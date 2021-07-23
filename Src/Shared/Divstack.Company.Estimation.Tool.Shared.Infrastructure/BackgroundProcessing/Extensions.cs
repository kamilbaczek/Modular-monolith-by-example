using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.BackgroundProcessing;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing
{
    internal static class Extensions
    {
        public static IServiceCollection AddBackgroundProcessing(this IServiceCollection services)
        {
            services.AddHangfire(configuration => { configuration.UseInMemoryStorage(); });
            services.AddHangfireServer();
            services.AddScoped<IBackgroundJobScheduler, BackgroundJobScheduler>();

            return services;
        }

        public static void UseBackgroundProcessing(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
        }
    }
}
