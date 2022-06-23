namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Bootstrapper;
using Domain.UserAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NServiceBus;
using NUnit.Framework;
using Shared.DDD.BuildingBlocks;
using ICommand = Application.Common.Contracts.ICommand;

[SetUpFixture]
[TestFixture]
public class ValuationsTesting
{
    [OneTimeSetUp]
    public Task RunBeforeAnyTests()
    {
        Configuration = CreateConfigurations();
        var startup = new Startup(Configuration);
        var services = new ServiceCollection();
        startup.ConfigureServices(services);

        ReplaceHostEnviromentToMock(services);
        ReplaceCurrentUserServiceToMock(services);
        _serviceScopeFactory = services.BuildServiceProvider()
            .GetService<IServiceScopeFactory>();
        return Task.CompletedTask;
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }

    internal static Guid CurrentUserId => Guid.NewGuid();

    internal static IConfigurationRoot? Configuration;
    private static IServiceScopeFactory? _serviceScopeFactory;

    private static IConfigurationRoot CreateConfigurations()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .AddUserSecrets<ValuationsTesting>();
        return builder.Build();
    }

    private static void ReplaceHostEnviromentToMock(ServiceCollection services)
    {
        services.AddSingleton(Mock.Of<IWebHostEnvironment>(hostEnvironment =>
            hostEnvironment.EnvironmentName == "Test" &&
            hostEnvironment.ApplicationName == "Divstack.Company.Estimation.Tool.Bootstrapper"));
    }

    private static void ReplaceCurrentUserServiceToMock(IServiceCollection services)
    {
        var currentUserServiceDescriptor = services.FirstOrDefault(serviceDescriptor =>
            serviceDescriptor.ServiceType == typeof(ICurrentUserService));
        services.Remove(currentUserServiceDescriptor!);
        services.AddTransient(_ =>
            Mock.Of<ICurrentUserService>(
                currentUserService => currentUserService.GetPublicUserId() == CurrentUserId));
    }

    public static async Task ExecuteCommandAsync(ICommand request)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

        await valuationsModule.ExecuteCommandAsync(request);
    }

    public static async Task<TResponse> ExecuteQueryAsync<TResponse>(IQuery<TResponse> request)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

        return await valuationsModule.ExecuteQueryAsync(request);
    }


    public static async Task ConsumeEvent<TEvent>(TEvent domainEvent) where TEvent : IntegrationEvent
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var integrationEventPublisher = scope.ServiceProvider.GetRequiredService<IHandleMessages<TEvent>>();
        await integrationEventPublisher.Handle(domainEvent, null);
    }
}
