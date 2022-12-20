namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common.Engine.Mocks;

using Microsoft.AspNetCore.Hosting;
using Moq;

internal static class EnvironmentMock
{
    private const string FakeApplicationName = "Divstack.Company.Estimation.Tool.Bootstrapper";
    private const string FakeEnvironmentName = "Test";

    internal static void ReplaceHostEnvironment(this ServiceCollection services) =>
        services.AddSingleton(Mock.Of<IWebHostEnvironment>(hostEnvironment =>
            hostEnvironment.EnvironmentName == FakeEnvironmentName &&
            hostEnvironment.ApplicationName == FakeApplicationName));
}
