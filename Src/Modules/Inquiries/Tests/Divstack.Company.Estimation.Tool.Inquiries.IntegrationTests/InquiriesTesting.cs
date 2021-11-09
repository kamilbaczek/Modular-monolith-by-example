using  System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Shared.IntegrationTesting;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;

namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationTests
{
    [SetUpFixture]
    [TestFixture]
    public class InquiriesTesting
    {
        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            Configuration = CreateConfigurations();
            var startup = new Startup(Configuration);
            var services = new ServiceCollection();

            ReplaceHostEnviromentToMock(services);
            ReplaceCurrentUserServiceToMock(services);

            services.AddLogging();
            startup.ConfigureServices(services);

            _serviceScopeFactory = services.BuildServiceProvider()
                .GetService<IServiceScopeFactory>();

            _checkpoint = new RespawnMySql
            {
                TablesToIgnore = new[] { IgnoredTable },
                DbAdapter = DbAdapter.MySql
            };

            await EnsureDatabase();
        }


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }

        private const string InquiriesConfigurationFile = "inquiries-module-integration-tests.json";

        private const string ConnectionStringName = "Inquiries";
        private const string IgnoredTable = "__EFMigrationsHistory";

        internal static IConfigurationRoot Configuration;
        private static IServiceScopeFactory _serviceScopeFactory;
        private static RespawnMySql _checkpoint;
        public static IServiceScope CreateServiceScope => _serviceScopeFactory.CreateScope();

        internal static Guid CurrentUserId { get; set; }

        private static IConfigurationRoot CreateConfigurations()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(InquiriesConfigurationFile, true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets<InquiriesTesting>();
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

        public static async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> request)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var inquiriesModule = scope.ServiceProvider.GetRequiredService<IInquiriesModule>();

            return await inquiriesModule.ExecuteCommandAsync(request);
        }

        public static async Task<TResponse> ExecuteQueryAsync<TResponse>(IQuery<TResponse> request)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var inquiriesModule = scope.ServiceProvider.GetRequiredService<IInquiriesModule>();

            return await inquiriesModule.ExecuteQueryAsync(request);
        }

        protected static void EnsureDatabaseModule(IServiceScope serviceScope)
        {
            var inquiriesContext = serviceScope.ServiceProvider.GetRequiredService<InquiriesContext>();
            inquiriesContext.Database.Migrate();
        }

        private static async Task EnsureDatabase()
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var usersContext = scope.ServiceProvider.GetRequiredService<UsersContext>();
            await usersContext.Database.MigrateAsync();

            var usersSeeder = scope.ServiceProvider.GetRequiredService<IUsersSeeder>();
            await usersSeeder.SeedAdminUserAsync();

            EnsureDatabaseModule(scope);
        }

        public static async Task ResetState()
        {
            using var scope = CreateServiceScope;
            var connectionString = Configuration.GetConnectionString(ConnectionStringName);
            await _checkpoint.Reset(connectionString);
        }
    }
}