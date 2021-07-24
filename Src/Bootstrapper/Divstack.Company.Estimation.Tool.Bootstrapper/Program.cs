using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Bootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    builder.AddEnvironmentVariables();
                    if(hostContext.HostingEnvironment.IsEnvironment("Local"))
                        builder.AddUserSecrets<Startup>();
                });
    }
}
