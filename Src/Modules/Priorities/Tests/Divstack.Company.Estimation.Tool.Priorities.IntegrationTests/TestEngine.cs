namespace Divstack.Company.Estimation.Tool.Priorities.IntegrationTests;

using Bootstrapper;
using Common.Engine;
using Divstack.Company.Estimation.Tool.Priorities.IntegrationTests.Common.Engine.Mocks;
using Microsoft.Extensions.Configuration;
using Users.Domain;

[SetUpFixture]
public class TestEngine
{
    internal static IServiceScopeFactory ServiceScopeFactory;
    internal static IMock<IDateTimeProvider> dateTimeProviderMock;
    
    [OneTimeSetUp]
    public static async Task RunBeforeAnyTestsAsync()
    {
        await PersistenceContainer.StartAsync();

        var configuration = BuildConfiguration();
        var startup = new Startup(configuration);
        var services = new ServiceCollection();
        startup.ConfigureServices(services);
        services.ReplaceCurrentUserService();
        services.MockInquiriesModule();

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
