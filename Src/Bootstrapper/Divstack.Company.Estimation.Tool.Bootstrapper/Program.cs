namespace Divstack.Company.Estimation.Tool.Bootstrapper;

using Configurations;
using Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Shared.Infrastructure.Observability;

public sealed class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseObservability();
            })
            .ConfigureAppConfiguration((hostContext, builder) =>
            {
                var envName = hostContext.HostingEnvironment.EnvironmentName;
                builder.AddAllConfigurationsFromSolution(envName);
                builder.AddEnvironmentVariables();

                if (hostContext.HostingEnvironment.IsForDevs())
                {
                    builder.AddUserSecrets<Startup>();
                }
            });
    }
}
