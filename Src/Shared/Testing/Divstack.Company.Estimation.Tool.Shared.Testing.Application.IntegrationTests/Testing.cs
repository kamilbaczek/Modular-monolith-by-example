using System.IO;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SingOut;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.Application.IntegrationTests
{
    public abstract class Testing
    {
        private static IConfigurationRoot _configuration;
        protected static IServiceScopeFactory ServiceScopeFactory;
        private static Checkpoint _checkpoint;

        public static IServiceScope CreateServiceScope => ServiceScopeFactory.CreateScope();

        protected void InitTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Test" &&
                w.ApplicationName == "Divstack.Company.Estimation.Tool.Bootstrapper"));

            services.AddLogging();

            startup.ConfigureServices(services);

            ServiceScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] {"__EFMigrationsHistory"}
            };

            EnsureDatabase();
        }

        protected abstract void EnsureDatabaseModule(IServiceScope serviceScope);

        private void EnsureDatabase()
        {
            var scope = InitUsers();

            EnsureDatabaseModule(scope);
        }

        public static IServiceScope InitUsers()
        {
            using var scope = ServiceScopeFactory.CreateScope();

            var usersContext = scope.ServiceProvider.GetRequiredService<UsersContext>();
            usersContext.Database.Migrate();

            var usersSeeder = scope.ServiceProvider.GetRequiredService<IUsersSeeder>();
            usersSeeder.SeedAdminUser();
            return scope;
        }

        public static async Task RunAsAdministratorAsync()
        {
            await RunAsUserAsync("admin@divstack.pl", "Administrator1234!");
        }

        public static async Task RunAsUserAsync(string userName, string password)
        {
            using var scope = ServiceScopeFactory.CreateScope();

            var usersSeeder = scope.ServiceProvider.GetRequiredService<IUserModule>();
            await usersSeeder.ExecuteCommandAsync(new SignInCommand(userName, password));
        }

        public static async Task ResetState()
        {
            using var scope = CreateServiceScope;
            var userModule = scope.ServiceProvider.GetRequiredService<IUserModule>();
            await userModule.ExecuteCommandAsync(new SignOutCommand());
            var connectionString = _configuration.GetConnectionString("Valuations");
            await _checkpoint.Reset(connectionString);
        }
    }
}
