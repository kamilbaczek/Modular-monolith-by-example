using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions;
using Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SignIn;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests
{
    public abstract class IntegrationTest<TModuleContext> where TModuleContext: DbContext
    {
       private const string Bearer = "bearer";

        protected readonly HttpClient HttpClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.ReplaceToInMemoryInstance<UsersContext>();
                        services.ReplaceToInMemoryInstance<TModuleContext>();

                    });
                });

            HttpClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            var token = await GetJwtAsync();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer,token);
        }

        private async Task<string> GetJwtAsync()
        {
            var response = await HttpClient.PostAsJsonAsync(
                "https://localhost/api/users-module/Authentication",
                new SignInCommand(
                    "admin@divstack.pl",
                    "3wsx$EDC5rfvtest4"));


            var registrationResponse = await response.Content.ReadAsAsync<SignInResponse>();
            return registrationResponse.Token;
        }


    }
}
