namespace Divstack.Company.Estimation.Tool.Bootstrapper;

using Common.Configurations;
using Common.Extensions;
using Shared.Infrastructure.Configuration;

/// <summary>
/// Entry point to  application
/// </summary>
public sealed class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    /// CreateHostBuilder
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration((hostContext, builder) =>
            {
                var envName = hostContext.HostingEnvironment.EnvironmentName;
                builder.AddAllConfigurationsFromSolution(envName);
                builder.AddEnvironmentVariables();
                if (hostContext.HostingEnvironment.IsForDevs())
                    builder.AddUserSecrets<Startup>();

                var configuration = builder.Build();
                builder.AddApplicationConfiguration(configuration);
            });
    }
}
