namespace Divstack.Company.Estimation.Tool.Bootstrapper;

using Estimations.Api;
using Inquiries.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Modules.Emails.Bootstrapper;
using Payments.Api;
using Reminders;
using Services.Api;
using Shared.Infrastructure.Api;
using Users.Api;

public sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSharedInfrastructure(Configuration);
        services.AddUsersModule(Configuration);
        services.AddServicesModule(Configuration);
        services.AddInquiriesModule(Configuration);
        services.AddValuationsModule(Configuration);
        services.AddPaymentsModule(Configuration);
        services.AddEmailsModule();
        services.AddRemindersModule();
    }

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSharedInfrastructure();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        app.UseValuationModule();
    }
}
