using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Api;
using Divstack.Company.Estimation.Tool.Services.Core.Services;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Categories;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Fakes;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Extensions;
using Divstack.Company.Estimation.Tool.Shared.Testing.IntegrationTests.Json;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Services.IntegrationsTests.Services
{
    public class ServicesTests : ServicesModuleIntegrationTest
    {
        [Fact]
        public async Task Given_GetAll_WithoutAnyServicesReturnsEmptyResponse()
        {
            var client = await Application.GetAuthenticatedClientAsync();

            var response = await client.GetAsync(Routing.Services.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var services = await response.GetResponseContent<List<ServiceDto>>();
            services.Should().BeEmpty();
        }

        [Fact]
        public async Task Given_GetAll_ReturnsCorrectData()
        {
            var fakeCategory = Category.Create("test", "test");
            var fakeService = Service.Create("test", "test", fakeCategory, new FakeCurrentUserService());
            await SeedService(fakeService);
            var client = await Application.GetAuthenticatedClientAsync();

            var response = await client.GetAsync(Routing.Services.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var services = await response.GetResponseContent<List<ServiceDto>>();
            services.Count.Should().Be(1);
            services.First().AssertEquals(fakeService, fakeCategory);
        }

        [Fact]
        public async Task Given_Create_Then_ServicesIsSavedInDatabase()
        {
            var fakeCategory = Category.Create("test", "test");
            var createServiceRequest = GetFakeCreateServiceRequest(fakeCategory);
            await SeedCategory(fakeCategory);
            var client = await Application.GetAuthenticatedClientAsync();

            var response = await client.PostAsync(Routing.Services.Create, createServiceRequest);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            await EnsureServiceWasSaved(createServiceRequest.Name);
        }

        [Fact]
        public async Task Given_Delete_Then_ServiceIsDeleted()
        {
            var fakeCategory = Category.Create("test", "test");
            var fakeService = Service.Create("test", "test", fakeCategory, new FakeCurrentUserService());
            await SeedService(fakeService);
            var client = await Application.GetAuthenticatedClientAsync();
            var url = Routing.Services.Delete(fakeService.Id);

            var response = await client.DeleteAsync(url);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            await EnsureServiceWasDeleted(fakeService.Id);
        }
    }
}