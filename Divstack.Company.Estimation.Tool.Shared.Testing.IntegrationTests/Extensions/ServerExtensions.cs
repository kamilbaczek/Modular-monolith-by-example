using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Users.Api;
using Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.DTO.Authentication;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.Commands.SignIn;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions
{
    public static class ServerExtensions
    {
        private const string Bearer = "bearer";

        public static async Task ExecuteOnDatabaseContextAsync<T>(this WebApplicationFactory<Startup> application,
            Func<T, Task> asyncAction) where T : DbContext
        {
            using var scope = application.Server.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            await asyncAction(dbContext);
        }

        public static async Task<HttpClient> GetAuthenticatedClientAsync(
            this WebApplicationFactory<Startup> application)
        {
            var client = application.CreateClient();
            var token = await GetJwtAsync(application, client);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);


            return client;
        }

        private static async Task<string> GetJwtAsync(this WebApplicationFactory<Startup> application,
            HttpClient client)
        {
            var usersConfiguration = application.Server.Services.GetRequiredService<IAdminAccountConfiguration>();
            var response = await client.PostAsJsonAsync(
                Routing.Authentication.SignIn,
                new SignInRequest(
                    usersConfiguration.UserName,
                    usersConfiguration.Password));

            var signInResponse = await response.Content.ReadAsAsync<SignInResponse>();
            return signInResponse.Token;
        }
    }
}
