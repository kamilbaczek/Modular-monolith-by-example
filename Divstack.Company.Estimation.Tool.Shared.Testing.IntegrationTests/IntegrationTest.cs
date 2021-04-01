using System;
using Divstack.Company.Estimation.Tool.Bootstrapper;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests
{
    public abstract class IntegrationTest<TModuleContext> : IDisposable where TModuleContext: DbContext
    {
        protected readonly  WebApplicationFactory<Startup> Application;

        protected IntegrationTest()
        {
            Application =  new WebApplicationFactory<Startup>()
                  .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.ReplaceToInMemoryInstance<UsersContext>();
                        services.ReplaceToInMemoryInstance<TModuleContext>();

                    });
                });
        }

        public void Dispose()
        {
            Application.Dispose();
        }
    }
}
