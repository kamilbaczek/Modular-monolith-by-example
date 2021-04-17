using Divstack.Company.Estimation.Tool.Estimations.Api;
using Divstack.Company.Estimation.Tool.Modules.Emails.Bootstrapper;
using Divstack.Company.Estimation.Tool.Products.Api;
using Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api;
using Divstack.Company.Estimation.Tool.Users.Api;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Bootstrapper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedInfrastructure();
            services.AddUsersModule(Configuration);
            services.AddProductsModule(Configuration);
            services.AddValuationsModule(Configuration);
            services.AddEmailsModule();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IUsersSeeder usersSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSharedInfrastructure();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseUsersModule(usersSeeder);
        }
    }
}
