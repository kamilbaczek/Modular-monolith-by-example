using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using ICommand = Divstack.Company.Estimation.Tool.Valuations.Application.Contracts.ICommand;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests
{
    [SetUpFixture]
    [TestFixture]
    public class ValuationsTesting
    {
        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            Configuration = CreateConfigurations();
            var startup = new Startup(Configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);

            EnsureDatabaseModule(services);
            ReplaceHostEnviromentToMock(services);
            ReplaceCurrentUserServiceToMock(services);
            _serviceScopeFactory = services.BuildServiceProvider()
                .GetService<IServiceScopeFactory>();
            await EnsureDatabase(services);
        }


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }

        private const string ConnectionStringName = "Valuations";

        private static readonly MongoDbRunner Runner1 = MongoDbRunner.StartForDebugging();
        public static IServiceScope CreateServiceScope => _serviceScopeFactory.CreateScope();

        internal static Guid CurrentUserId { get; set; }

        internal static IConfigurationRoot Configuration;
        private static IServiceScopeFactory _serviceScopeFactory;
        internal static MongoDbRunner MongoDbInstance;

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

        private static void ReplaceCurrentUserServiceToMock(ServiceCollection services)
        {
            var currentUserServiceDescriptor = services.FirstOrDefault(serviceDescriptor =>
                serviceDescriptor.ServiceType == typeof(ICurrentUserService));
            services.Remove(currentUserServiceDescriptor);
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

        public static async Task<TResponse> ExecuteQueryAsync<TResponse>(Contracts.IQuery<TResponse> request)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

            return await valuationsModule.ExecuteQueryAsync(request);
        }


        public static async Task ConsumeEvent<TEvent>(TEvent domainEvent) where TEvent : IntegrationEvent
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var integrationEventPublisher = scope.ServiceProvider.GetRequiredService<INotificationHandler<TEvent>>();
            await integrationEventPublisher.Handle(domainEvent, CancellationToken.None);
        }

        protected static void EnsureDatabaseModule(ServiceCollection services)
        {
            MongoDbInstance = MongoDbRunner.Start();
            var currentUserServiceDescriptor = services.FirstOrDefault(serviceDescriptor =>
                serviceDescriptor.ServiceType == typeof(MongoClient));
            services.Remove(currentUserServiceDescriptor);

            var mongoClient = new MongoClient(MongoDbInstance.ConnectionString);
            services.AddSingleton(mongoClient);
        }

        private static async Task EnsureDatabase(ServiceCollection services)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var usersContext = scope.ServiceProvider.GetRequiredService<UsersContext>();
            await usersContext.Database.MigrateAsync();

            var usersSeeder = scope.ServiceProvider.GetRequiredService<IUsersSeeder>();
            await usersSeeder.SeedAdminUserAsync();
        }

        public static async Task RunAsAdministratorAsync()
        {
            await RunAsUserAsync("admin@divstack.pl");
        }

        public static async Task RunAsUserAsync(string userName)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var userModule = scope.ServiceProvider.GetRequiredService<IUserModule>();
            var user = await userModule.ExecuteQueryAsync(new GetUserDetailQueryByUsernameCommand(userName));
            CurrentUserId = user.PublicId;
        }

        public static Task ResetState()
        {
            MongoDbInstance.Dispose();

            return Task.CompletedTask;
        }
    }
}