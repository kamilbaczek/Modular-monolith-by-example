﻿namespace Divstack.Company.Estimation.Tool.Bootstrapper;

using Common.Configurations;
using Common.Extensions;
using Shared.Infrastructure.Api;

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
                webBuilder.ConfigureSharedInfrastructure();
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
