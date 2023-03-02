namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests;

using System.IO;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common.Engine;
using Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common.Engine.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

[SetUpFixture]
public class TestEngine
{
    internal static IServiceScopeFactory ServiceScopeFactory;

    [OneTimeSetUp]
    public static async Task RunBeforeAnyTests()
    {
        await PersistenceContainer.StartAsync();

        var configuration = BuildConfiguration();
        var startup = new Startup(configuration);
        var services = new ServiceCollection();
        startup.ConfigureServices(services);
        services.ReplaceCurrentUserService();

        ServiceScopeFactory = services.BuildServiceProvider()
            .GetService<IServiceScopeFactory>()!;
    }

    [OneTimeTearDown]
    public static void RunAfterAnyTests() => PersistenceContainer.Stop();

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .AddUserSecrets<TestEngine>();

        return builder.Build();
    }
}
