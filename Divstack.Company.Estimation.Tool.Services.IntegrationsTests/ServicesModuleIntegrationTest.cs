using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using Divstack.Company.Estimation.Tool.Services.DAL;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests
{
    public abstract class ServicesModuleIntegrationTest : IntegrationTest<ServicesContext>
    {
        protected async Task SeedService(Service fakeService)
        {
            await Application.ExecuteOnDatabaseContextAsync<ServicesContext>(async context =>
            {
                await context.Services.AddAsync(fakeService);
                await context.SaveChangesAsync();
            });
        }

        protected async Task SeedCategory(Category fakeCategory)
        {
            await Application.ExecuteOnDatabaseContextAsync<ServicesContext>(async context =>
            {
                await context.Categories.AddAsync(fakeCategory);
                await context.SaveChangesAsync();
            });
        }

        protected async Task EnsureServiceWasSaved(string name)
        {
            await Application.ExecuteOnDatabaseContextAsync<ServicesContext>(async context =>
            {
                var service = await context.Services.SingleOrDefaultAsync(service => service.Name == name);
                service.Should().NotBeNull();
            });
        }

        protected async Task EnsureServiceWasDeleted(Guid id)
        {
            await Application.ExecuteOnDatabaseContextAsync<ServicesContext>(async context =>
            {
                var service = await context.Services.SingleOrDefaultAsync(service => service.Id == id);
                service.Should().BeNull();
            });
        }

        protected static CreateServiceRequest GetFakeCreateServiceRequest(Category fakeCategory)
        {
            var createServiceRequest = new CreateServiceRequest
            {
                Description = "test",
                Name = "Test",
                CategoryId = fakeCategory.Id
            };

            return createServiceRequest;
        }
    }
}
