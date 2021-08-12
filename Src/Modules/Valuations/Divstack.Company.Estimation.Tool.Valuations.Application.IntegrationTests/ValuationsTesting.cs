using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
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
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets<ValuationsTesting>();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Test" &&
                w.ApplicationName == "Divstack.Company.Estimation.Tool.Bootstrapper"));


            var currentUserServiceDescriptor = services.FirstOrDefault(serviceDescriptor =>
                serviceDescriptor.ServiceType == typeof(ICurrentUserService));

            services.Remove(currentUserServiceDescriptor);

            services.AddTransient(_ =>
                Mock.Of<ICurrentUserService>(s => s.GetPublicUserId() == CurrentUserId));

            services.AddLogging();
            startup.ConfigureServices(services);

            _ServiceScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new RespawnMySql
            {
                TablesToIgnore = new[] {"__EFMigrationsHistory"},
                DbAdapter = DbAdapter.MySql
            };

            await EnsureDatabase();
        }


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }

        public static async Task ExecuteCommandAsync(ICommand request)
        {
            using var scope = _ServiceScopeFactory.CreateScope();

            var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

            await valuationsModule.ExecuteCommandAsync(request);
        }

        public static async Task<TResponse> ExecuteQueryAsync<TResponse>(Contracts.IQuery<TResponse> request)
        {
            using var scope = _ServiceScopeFactory.CreateScope();

            var valuationsModule = scope.ServiceProvider.GetRequiredService<IValuationsModule>();

            return await valuationsModule.ExecuteQueryAsync(request);
        }

        protected void EnsureDatabaseModule(IServiceScope serviceScope)
        {
            var valuationsContext = serviceScope.ServiceProvider.GetRequiredService<ValuationsContext>();
            valuationsContext.Database.Migrate();
        }

        internal static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _ServiceScopeFactory;
        private static RespawnMySql _checkpoint;
        internal static Guid CurrentUserId { get; set; }

        private async Task EnsureDatabase()
        {
            using var scope = _ServiceScopeFactory.CreateScope();

            var usersContext = scope.ServiceProvider.GetRequiredService<UsersContext>();
            usersContext.Database.Migrate();

            var usersSeeder = scope.ServiceProvider.GetRequiredService<IUsersSeeder>();
            await usersSeeder.SeedAdminUserAsync();

            EnsureDatabaseModule(scope);
        }

        public static IServiceScope CreateServiceScope => _ServiceScopeFactory.CreateScope();

        public static async Task RunAsAdministratorAsync()
        {
            await RunAsUserAsync("admin@divstack.pl");
        }

        public static async Task RunAsUserAsync(string userName)
        {
            using var scope = _ServiceScopeFactory.CreateScope();

            var userModule = scope.ServiceProvider.GetRequiredService<IUserModule>();
            var user = await userModule.ExecuteQueryAsync(new GetUserDetailQueryByUsernameCommand(userName));
            CurrentUserId = user.PublicId;
        }

        public static async Task ResetState()
        {
            using var scope = CreateServiceScope;
            var connectionString = _configuration.GetConnectionString("Valuations");
            await _checkpoint.Reset(connectionString);
        }
    }
}
