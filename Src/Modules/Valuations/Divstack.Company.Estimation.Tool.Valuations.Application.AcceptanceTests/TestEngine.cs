namespace Divstack.Company.Estimation.Tool.Valuations.Application.AcceptanceTests;

using Bootstrapper;
using Common.Engine;
using Common.Engine.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[Binding]
public class TestEngine
{
    private const string AppSettingsJsonFileName = "appsettings.json";

    internal static IServiceScopeFactory ServiceScopeFactory;

    [BeforeTestRun]
    public static async Task RunBeforeAnyTests()
    {
        await PersistenceContainer.StartAsync();

        var configuration = BuildConfiguration();
        var startup = new Startup(configuration);
        var services = new ServiceCollection();
        startup.ConfigureServices(services);

        services.ReplaceHostEnvironment();
        services.ReplaceIntegrationEventPublisher();
        services.ReplaceCurrentUserService();

        ServiceScopeFactory = services.BuildServiceProvider()
            .GetService<IServiceScopeFactory>()!;
    }

    [AfterTestRun]
    public static async Task RunAfterAnyTests() => await PersistenceContainer.StopAsync();

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(AppSettingsJsonFileName, true, true)
            .AddEnvironmentVariables()
            .AddUserSecrets<TestEngine>();

        return builder.Build();
    }
}
