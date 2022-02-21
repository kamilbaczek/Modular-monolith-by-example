namespace Divstack.Company.Estimation.Tool.Bootstrapper;

using Inquiries.Api;
using Modules.Emails.Bootstrapper;
using Payments.Api;
using Priorities.Api;
using Push;
using Reminders;
using Services.Api;
using Shared.Infrastructure.Api;
using Sms;
using Users.Api;
using Valuations.Api;

/// <summary>
///     Divstack.Company.Estimation.Tool.Bootstrapper entry point
/// </summary>
public sealed class Startup
{
    /// <summary>
    ///     Configuration
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    /// <summary>
    ///     Configure services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSharedInfrastructure(Configuration);

        services.AddUsersModule(Configuration);
        services.AddServicesModule(Configuration);
        services.AddInquiriesModule(Configuration);
        services.AddPaymentsModule(Configuration);
        services.AddValuationsModule(Configuration);
        services.AddPrioritiesModule(Configuration);
        services.AddRemindersModule();

        services.AddPushModule(Configuration);
        services.AddEmailsModule();
        services.AddSmsModule(Configuration);
    }

    /// <summary>
    ///     Configure application
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSharedInfrastructure();
        app.UsePaymentModule();
        app.UseValuationModule();
        app.UsePrioritiesModule();
        app.UsePushModule();
    }
}
